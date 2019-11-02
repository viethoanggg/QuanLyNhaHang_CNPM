using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhaHang.Services {
    public class PaginatedList<T> : List<T> {

        public PaginatedList (IEnumerable<T> source, int pageIndex, int pageSize, int count) {
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling (count / (double) pageSize);
            this.AddRange (source);

        }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasNext {
            get {
                return PageIndex < TotalPages ? true : false;
            }
        }
        public bool HasPrevious {
            get {
                return PageIndex > 1 ? true : false;
            }
        }

        public static PaginatedList<T> Create (IEnumerable<T> source, int pageIndex, int pageSize) {
            var items = source.Skip ((pageIndex - 1) * pageSize).Take<T> (pageSize);
            int count = source.Count ();
            return new PaginatedList<T> (items, pageIndex, pageSize, count);
        }
    }
}