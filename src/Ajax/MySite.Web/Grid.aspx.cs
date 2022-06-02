using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace MySite.Web
{
    public partial class Grid : System.Web.UI.Page
    {
        public DataTable Sellers
        {
            get
            {
                DataTable data = Session["Data"] as DataTable;

                if (data == null)
                {
                    data = GetSellers();
                    Session["Data"] = data;
                }

                return data;
            }
        }

        public DataTable GetSellers()
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID", typeof(int));
            data.Columns.Add("Name");
            data.Columns.Add("Age", typeof(int)).DefaultValue = 0;
            data.Columns.Add("BirthDate", typeof(DateTime));
            data.Columns.Add("Rating", typeof(int)).DefaultValue = 0;
            data.Columns.Add("City");
            data.PrimaryKey = new DataColumn[] { data.Columns["ID"] };

            List<string> firstNames = new List<string>() { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige" };
            List<string> cities = this.GetCities();
            List<DateTime> birthDates = new List<DateTime>() { DateTime.Parse("1948/12/08"), DateTime.Parse("1952/02/19"), DateTime.Parse("1963/08/30"), DateTime.Parse("1937/09/19"), DateTime.Parse("1955/03/04"), DateTime.Parse("1963/07/02"), DateTime.Parse("1960/05/29"), DateTime.Parse("1958/01/09"), DateTime.Parse("1966/01/27"), DateTime.Parse("1966/03/27") };
            Random random = new Random();

            for (int i = 0; i < 84; i++)
            {
                DateTime birthDate = birthDates[random.Next(birthDates.Count - 1)];
                data.Rows.Add(
                    random.Next(10000, int.MaxValue),
                    firstNames[random.Next(firstNames.Count - 1)],
                    DateTime.Now.Year - birthDate.Year, birthDate, random.Next(1, 5),
                    cities[random.Next(cities.Count - 1)]);
            }

            return data;
        }

        public List<string> GetCities()
        {
            return new List<string>()
        {
            "Seattle",
            "Tacoma",
            "Kirkland",
            "Redmond",
            "London",
            "Philadelphia",
            "New York",
            "Seattle",
            "London",
            "Boston"
        };
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = this.Sellers;
        }

        protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            Hashtable table = new Hashtable();
            (e.Item as GridEditableItem).ExtractValues(table);

            DataRow row = this.Sellers.Rows.Find((e.Item as GridEditableItem).GetDataKeyValue("ID"));

            foreach (string key in table.Keys)
            {
                row[key] = table[key] ?? DBNull.Value;
            }
            DateTime date;
            if (DateTime.TryParse((row["BirthDate"].ToString()), out date))
            {
                row["Age"] = DateTime.Now.Year - date.Year;
            }
            else
            {
                row["Age"] = 0;
            }
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            Hashtable table = new Hashtable();
            (e.Item as GridEditableItem).ExtractValues(table);
            DataRow row = this.Sellers.NewRow();

            foreach (string key in table.Keys)
            {
                if (table[key] != null)
                {
                    row[key] = table[key];
                }
            }
            row["ID"] = new Random().Next(int.MaxValue);
            DateTime date;
            if (DateTime.TryParse((row["BirthDate"].ToString()), out date))
            {
                row["Age"] = DateTime.Now.Date.Year - date.Year;
            }
            this.Sellers.Rows.InsertAt(row, 0);
        }

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            this.Sellers.Rows.Remove(this.Sellers.Rows.Find((e.Item as GridEditableItem).GetDataKeyValue("ID")));
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            RadComboBox comboBox = e.Item.FindControl("RCB_City") as RadComboBox;
            if (comboBox != null)
            {
                if (!(e.Item.DataItem is GridInsertionObject))
                {
                    comboBox.SelectedValue = (e.Item.DataItem as DataRowView)["City"].ToString();
                }
                comboBox.DataTextField = string.Empty;
                comboBox.DataSource = this.GetCities();
                comboBox.DataBind();
                if (this.RadGrid1.ResolvedRenderMode == RenderMode.Mobile)
                {
                    (e.Item.FindControl("TB_Age") as WebControl).Enabled = false;
                }
                else
                {
                    ((e.Item as GridEditableItem)["Age"].Controls[0] as WebControl).Enabled = false;
                }
            }
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            GridHeaderItem headerItem = e.Item as GridHeaderItem;
            if (headerItem != null)
            {
                headerItem["EditColumn"].Text = string.Empty;
                headerItem["DeleteColumn"].Text = string.Empty;
            }
        }
    }
}
