using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdareCode.Models;
using AdareCode.DAL;

namespace AdareCode.BL
{
    public class ShowCollector
    {
        public enum ShowType : int { PrintShow = 1, EmailShow = 2, FaxShow = 3 };

        public IDateString DateFormat
        {
            set;
            get;
        }

        public ShowCollector(IDateString dateformat = null)
        {
            DateFormat = (dateformat == null) ? new AdareDateString() : dateformat;
        }

        public List<SelectListItem> GetShows(ShowType tp, AdareContext db)
        {
            var res = new List<SelectListItem>();

            var showlist = db.AdareShows.Where(p => p.EventTypeId == (int)tp);

            showlist.ToList().ForEach(s => res.Add(GetEventItem(s)));

            // allow null in select list
            res.Add(new SelectListItem
            {
                Selected = true,
                Text = String.Empty,
                Value = "0",
            });

            return res;
        }

        public List<SelectListItem> GetAllShows(AdareContext db)
        {
            var res = new List<SelectListItem>();

            db.AdareShows.ToList().ForEach(s => res.Add(GetEventItem(s)));

            if (res.Count > 0)
            {
                res[0].Selected = true;
            }

            return res;
        }

        private SelectListItem GetEventItem(AdareShow s)
        {
            string dt = DateFormat.GetDateString(s.EventDate);
            return new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = string.Format(_descriptionformat, s.ShowType.Description, dt),
            };
        }

        private readonly string _descriptionformat = "{0} - {1}";
    }
}