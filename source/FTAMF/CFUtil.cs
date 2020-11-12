using OpenMcdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTAMF
{
    class CFUtil
    {
		public static List<CFNode> ExploreStorage(CFStorage storage, string path)
		{
			List<CFNode> listCFItems = new List<CFNode>();
			storage.VisitEntries(delegate (CFItem item)
			{
				CFUtil.AddItemToList(item, path, listCFItems);
			}, false);
			return listCFItems;
		}

		public static void AddItemToList(CFItem item, string path, List<CFNode> listCFItems)
		{
			CFNode item2 = new CFNode
			{
				Name = item.Name,
				IsStream = item.IsStream,
				IsFolder = item.IsStorage,
				IsRoot = item.IsRoot,
				ExploreFolder = (item.IsStorage | item.IsRoot),
				Path = path,
				CreationDate = item.CreationDate,
				ModifyDate = item.ModifyDate,
				LastAccess = item.ModifyDate,
				Size = item.Size,
				Id = item.CLSID.ToString()
			};
			listCFItems.Add(item2);
		}

		public static void AddItemsToTreeViewNode(ref CompoundFile cf, List<CFNode> list, TreeView treeview, TreeNode parentNode = null)
		{
			var orderedList = from x in list
							orderby !x.IsFolder, x.Name
							select x;
			foreach (CFNode currentNode in orderedList)
            {
                int num = currentNode.IsFolder ? 2 : 4;
                if (currentNode.IsStream && MSUtil.IsCompoundFile(MSUtil.CFtoMStream(CFUtil.GetStream(ref cf, currentNode.Path, currentNode.Name))))
                {
                    num = 1;
                    currentNode.ExploreCFstream = true;
                    currentNode.Type = "Container";
                }
                if (currentNode.IsStream)
                {
                    currentNode.Type = "File";
                }
                currentNode.CFidx = ((CFNode)parentNode.Tag).CFidx;
                TreeNode node = new TreeNode
                {
                    Text = currentNode.Name,
                    ImageIndex = num,
                    SelectedImageIndex = num,
                    Tag = currentNode
                };
                if (parentNode == null)
                {
                    treeview.Nodes.Add(node);
                }
                else
                {
                    parentNode.Nodes.Add(node);
                }
            }
        }

		public static CFStream GetStream(ref CompoundFile cf, string path, string name)
		{
			List<string> pathList = null;
			if (path != "%Root_Entry%")
			{
				pathList = path.Split(new char[]
				{
					'/'
				}).ToList<string>();
			}
			CFStorage rootStorage = cf.RootStorage;
			return CFUtil.GetStorage(pathList, ref rootStorage).GetStream(name);
		}

		public static CFStorage GetStorage(List<string> pathList, ref CFStorage storage)
		{
			if (pathList == null || pathList[0] == "")
			{
				return storage;
			}
			if (pathList.Count<string>() > 1)
			{
				int index = pathList.Count<string>() - 1;
				string storageName = pathList[index];
				pathList.RemoveAt(index);
				return CFUtil.GetStorage(pathList, ref storage).GetStorage(storageName);
			}
			return storage.GetStorage(pathList[0]);
		}

		public static string GetText(ref CompoundFile cf, CFNode nodo)
		{
			string a = Path.GetExtension(nodo.Name).ToLower();
			CFStream stream = CFUtil.GetStream(ref cf, nodo.Path, nodo.Name);
			MemoryStream input = MSUtil.CFtoMStream(stream);
			MemoryStream stream2;
			if (a == "")
			{
				stream2 = MSUtil.RemoveTrailingSegment(input, 12);
			}
			else if (MSUtil.IsCompressedWithLW77(stream))
			{
				stream2 = MSUtil.UncompressLW77(input);
			}
			else
			{
				stream2 = MSUtil.RemoveTrailingSegment(input, 8);
			}
			return new StreamReader(stream2, (a == ".csv") ? Encoding.ASCII : Encoding.Unicode).ReadToEnd();
		}
	}
}
