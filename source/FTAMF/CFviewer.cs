using OpenMcdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FTAMF
{
    public partial class CFviewer : DockContent
    {
		private TabPage _tabHexViewer;
		private TabPage _tabTextViewer;
        private TabPage _tabImageViewer;
		private ByteViewer byteViewer;
		private List<CompoundFile> _listCF = new List<CompoundFile>();
		private ImageList _icons = new ImageList();
		public static string[] _textFiles = {".par", ".xml", ".txt", ".mcr", "", ".csv" };
		public static string[] _imageFiles = { ".bmp", ".jpg", ".jpeg" };

		public CFviewer(CompoundFile cf)
		{
			InitializeComponent();
			
			_tabHexViewer = tabHexViewer;
			_tabTextViewer = tabTextViewer;
			_tabImageViewer = tabImageViewer;
			tabControl1.Controls.Remove(tabHexViewer);
			tabControl1.Controls.Remove(tabTextViewer);
			tabControl1.Controls.Remove(tabImageViewer);
			byteViewer = new ByteViewer();
			byteViewer.SetBytes(new byte[0]);
			byteViewer.Dock = DockStyle.Fill;
			tabHexViewer.Controls.Add(byteViewer);
			_icons.Images.Add(Properties.Resources.brown_cab);
			_icons.Images.Add(Properties.Resources.blue_cab);
			_icons.Images.Add(Properties.Resources.closed_folder);
			_icons.Images.Add(Properties.Resources.open_folder);
			_icons.Images.Add(Properties.Resources.any_file);
			treeView1.ImageList = _icons;
			SetRoot("Root", 0);
			_listCF.Add(cf);
			FormClosing += new FormClosingEventHandler(CFviewerIsClosing);
		}



        private void SetRoot(string name, int idx)
		{
			CFNode tag = new CFNode
			{
				Name = "(Root Storage)",
				IsStream = false,
				IsFolder = true,
				IsRoot = true,
				ExploreFolder = true,
				Path = "%Root_Entry%",
				CFidx = idx
			};
			TreeNode node = new TreeNode
			{
				Text = name,
				Tag = tag
			};
			treeView1.Nodes.Add(node);
		}

		private void BtnSaveImage_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = Path.GetFileName(((CFNode)treeView1.SelectedNode.Tag).Name);
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				new Bitmap(ImageViewer.Image).Save(saveFileDialog.FileName, ImageFormat.Bmp);
			}
		}

		#region Updating tabs

		private void EnableInfoPanelFields(bool flag)
		{
			lblTamaño.Visible = (txtSize.Visible = !flag);
			txtClsID.Visible = flag;
			lblClaseID.Visible = flag;
		}

		/// <summary>
		/// Update the information panel with date from the treenode.
		/// </summary>
		/// <param name="node"></param>
		private void UpdateInfoPanel(TreeNode node)
		{
			CFNode cFNode = (CFNode)node.Tag;
			EnableInfoPanelFields(cFNode.IsFolder);
			txtName.Text = cFNode.Name;
			txtSize.Text = cFNode.Size.ToString("N0") + " bytes";
			txtClsID.Text = ((cFNode.Id != null) ? cFNode.Id : "CLSID_NULL");
			txtCreationDate.Text = cFNode.CreationDate.ToString();
			txtModifyDate.Text = cFNode.ModifyDate.ToString();
			txtLastAccess.Text = cFNode.LastAccess.ToString();
			if (cFNode.IsFolder)
			{
				List<string> pathList = null;
				string text = cFNode.Path;
				if (text != "%Root_Entry%")
				{
					if (text != "")
					{
						text += "/";
					}
					text += cFNode.Name;
					pathList = text.Split(new char[]
					{
						'/'
					}).ToList<string>();
				}
				else
				{
					text = "";
				}
				if (cFNode.ExploreFolder)
				{
					CompoundFile compoundFile = _listCF[cFNode.CFidx];
					CFStorage rootStorage = compoundFile.RootStorage;
					CFUtil.AddItemsToTreeViewNode(ref compoundFile, CFUtil.ExploreStorage(CFUtil.GetStorage(pathList, ref rootStorage), text), treeView1, node);
					cFNode.ExploreFolder = false;
					node.Tag = cFNode;
				}
			}
			if (cFNode.IsStream & cFNode.ExploreCFstream)
			{
				List<string> pathList2 = null;
				string path = "";
				CompoundFile compoundFile2 = _listCF[cFNode.CFidx];
				Stream ms1 = MSUtil.CFtoMStream(CFUtil.GetStream(ref compoundFile2, cFNode.Path, cFNode.Name));
				MemoryStream memoryStream = new MemoryStream();
				using (MemoryStream ms2 = MSUtil.UncompressLW77(ms1))
				{
					ms2.CopyTo(memoryStream);
				}
				if (memoryStream.Length >= ms1.Length)
                {
					CompoundFile compoundFile3 = new CompoundFile(memoryStream);
					CFStorage rootStorage2 = compoundFile3.RootStorage;
					CFUtil.AddItemsToTreeViewNode(ref compoundFile3, CFUtil.ExploreStorage(CFUtil.GetStorage(pathList2, ref rootStorage2), path), treeView1, node);
					foreach (TreeNode item in node.Nodes)
					{
						((CFNode)item.Tag).CFidx = _listCF.Count();
					}
					_listCF.Add(compoundFile3);
				}
				cFNode.ExploreCFstream = false;
			}
		}

		/// <summary>
		/// Load data in Text tab.
		/// </summary>
		/// <param name="nodo"></param>
		/// <param name="ext"></param>
		private void LoadText(CFNode nodo, string ext)
		{
			CompoundFile compoundFile = _listCF[nodo.CFidx];
			CFStream stream = CFUtil.GetStream(ref compoundFile, nodo.Path, nodo.Name);
			MemoryStream memoryStream = MSUtil.CFtoMStream(stream);
			MemoryStream stream2;
			if (ext == "")
			{
				stream2 = MSUtil.RemoveTrailingSegment(memoryStream, 12);
			}
			else if (MSUtil.IsCompressedWithLW77(stream))
			{
				stream2 = MSUtil.UncompressLW77(memoryStream);
			}
			else
			{
				stream2 = MSUtil.RemoveTrailingSegment(memoryStream, 8);
			}
			StreamReader streamReader = new StreamReader(stream2, (ext == ".csv") ? Encoding.ASCII : Encoding.Unicode);
			RtfViewer.Text = streamReader.ReadToEnd();
			byteViewer.SetBytes(memoryStream.ToArray());
		}

		/// <summary>
		/// Load data in Image tab.
		/// </summary>
		/// <param name="tempNode"></param>
		private void LoadImage(CFNode tempNode)
		{
			ImageViewer.Image = null;
			TxtDimensions.Text = "Dimensions: ???";
			TxtResolution.Text = "Resolution: ???";
			CompoundFile compoundFile = _listCF[tempNode.CFidx];
			CFStream stream = CFUtil.GetStream(ref compoundFile, tempNode.Path, tempNode.Name);
			int num = MSUtil.VerifyIfImage(stream);
			if (num > 0)
			{
				MemoryStream memoryStream = new MemoryStream();
				if (num == 1)
				{
					memoryStream = MSUtil.UncompressLW77(MSUtil.CFtoMStream(stream));
				}
				if (num == 2)
				{
					memoryStream = MSUtil.RemoveTrailingSegment(MSUtil.CFtoMStream(stream), 8);
				}
				if (memoryStream != null & memoryStream.Length != 0L)
				{
					ImageViewer.Image = null;
					ImageViewer.Image = Image.FromStream(memoryStream);
					//TxtDimensions.Text = string.Format("Dimensions: {0}px x {1}px", ImageViewer.Image.Width, ImageViewer.Image.Height);
					//TxtResolution.Text = string.Format("Resolution: {0}dpi x {1}dpi", ImageViewer.Image.HorizontalResolution, ImageViewer.Image.VerticalResolution);
					TxtDimensions.Text = $"Dimensions: {ImageViewer.Image.Width}px x {ImageViewer.Image.Height}px";
					TxtResolution.Text = $"Resolution: {ImageViewer.Image.HorizontalResolution}dpi x {ImageViewer.Image.VerticalResolution}dpi";
				}
				memoryStream.Dispose();
			}
		}

		/// <summary>
		/// Load data in Hexadecimal tab
		/// </summary>
		/// <param name="tempNode"></param>
		private void LoadHexDump(CFNode tempNode)
		{
			CompoundFile compoundFile = _listCF[tempNode.CFidx];
			byteViewer.SetBytes(MSUtil.CFtoMStream(CFUtil.GetStream(ref compoundFile, tempNode.Path, tempNode.Name)).ToArray());
		}

        #endregion

		#region Events
		private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Level > 0 && e.Node.ImageIndex == 2)
			{
				e.Node.ImageIndex = 3;
				e.Node.SelectedImageIndex = 3;
			}
		}

		private void TreeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Level > 0 && e.Node.ImageIndex == 3)
			{
				e.Node.ImageIndex = 2;
				e.Node.SelectedImageIndex = 2;
			}
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateInfoPanel(e.Node);
			CFNode cFNode = (CFNode)e.Node.Tag;
			string text = Path.GetExtension(cFNode.Name).ToLower();

			if (!cFNode.IsStream)
			{
				tabControl1.Controls.Remove(tabHexViewer);
				tabControl1.Controls.Remove(tabTextViewer);
				tabControl1.Controls.Remove(tabImageViewer);
				byteViewer.SetBytes(new byte[0]);
				return;
			}
			if (_imageFiles.Contains(text))
			{
				if (!tabControl1.Controls.Contains(_tabHexViewer))
				{
					tabControl1.Controls.Add(_tabHexViewer);
				}
				if (!tabControl1.Controls.Contains(_tabImageViewer))
				{
					tabControl1.Controls.Add(_tabImageViewer);
				}
				if (tabControl1.Controls.Contains(_tabTextViewer))
				{
					tabControl1.Controls.Remove(_tabTextViewer);
				}
				LoadHexDump(cFNode);
				LoadImage(cFNode);
				return;
			}
			if (_textFiles.Contains(text))
			{
				if (!tabControl1.Controls.Contains(_tabHexViewer))
				{
					tabControl1.Controls.Add(_tabHexViewer);
				}
				if (!tabControl1.Controls.Contains(_tabTextViewer))
				{
					tabControl1.Controls.Add(_tabTextViewer);
				}
				if (tabControl1.Controls.Contains(_tabImageViewer))
				{
					tabControl1.Controls.Remove(_tabImageViewer);
				}
				LoadText(cFNode, text);
				return;
			}
			if (!tabControl1.Controls.Contains(_tabHexViewer))
			{
				tabControl1.Controls.Add(_tabHexViewer);
			}
			LoadHexDump(cFNode);
		}

		private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			CFNode cFNode = (CFNode)e.Node.Tag;
			if (cFNode.IsStream & cFNode.ExploreCFstream)
			{
				CompoundFile compoundFile = _listCF[cFNode.CFidx];
				Stream arg_50_0 = MSUtil.CFtoMStream(CFUtil.GetStream(ref compoundFile, cFNode.Path, cFNode.Name));
				MemoryStream memoryStream = new MemoryStream();
				using (MemoryStream memoryStream2 = MSUtil.UncompressLW77(arg_50_0))
				{
					memoryStream2.CopyTo(memoryStream);
				}
				new CompoundFile(memoryStream);
			}
		}

		private void CFviewerIsClosing(object sender, FormClosingEventArgs e)
		{
			foreach (CompoundFile cf in _listCF)
			{
				cf.Close();
			}
			_listCF.Clear();
		}

		#endregion
	}
}
