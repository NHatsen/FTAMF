using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTAMF
{
    class CFNode
    {
		public string Name
		{
			get;
			set;
		}

		public bool IsFolder
		{
			get;
			set;
		}

		public bool IsStream
		{
			get;
			set;
		}

		public bool IsRoot
		{
			get;
			set;
		}

		public bool ExploreFolder
		{
			get;
			set;
		}

		public bool ExploreCFstream
		{
			get;
			set;
		}

		public string Path
		{
			get;
			set;
		}

		public List<string> PathList
		{
			get;
			set;
		}

		public DateTime CreationDate
		{
			get;
			set;
		}

		public DateTime ModifyDate
		{
			get;
			set;
		}

		public DateTime LastAccess
		{
			get;
			set;
		}

		public long Size
		{
			get;
			set;
		}

		public string Id
		{
			get;
			set;
		}

		public string Type
		{
			get;
			set;
		}

		public int CFidx
		{
			get;
			set;
		}
	}
}
