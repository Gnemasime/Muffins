using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Muffins.Models
{
    public class Orders
    {
        //1
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  OrderNo { get; set; }
        public int ItemNo { get; set; }
        public virtual MuffinItems MuffinItems { get; set; }
        public string Customername { get; set; }
        public string Role { get; set; }
        public int NumMuffins { get; set; }
        public double BasicCost { get; set; }
       public double DiscAmount { get; set; }
        public double VatAmount { get; set; }
        public double Total { get; set; }

        //3
        //pull price
        public double Pullprice ()
        {
            AppDbContext db = new AppDbContext();
            var gh = (from y in db.muffinItems
                      where y.ItemNo == ItemNo
                      select y.Price).FirstOrDefault();

            return gh;
        }

        //Pull discountrate
        public double Pulldisc()
        {
            AppDbContext database = new AppDbContext();
            var disc = (from i in database.muffinItems
                        where i.ItemNo == ItemNo
                        select i.DscRate).FirstOrDefault();

            return disc;
        }

        //pull vat Rate
        public double Pullvatrate()
        {
            AppDbContext db = new AppDbContext();
            var vt = (from h in db.muffinItems
                      where h.ItemNo == ItemNo
                      select h.VatRate).FirstOrDefault();
            return vt;
        }

        //basic
        public double CalcbasicCost()
        {
            return Pullprice() * NumMuffins;
        }

        //CalcDiscount
        public double CalcDiscount()
        {
            if(Role == "Staff" && NumMuffins > 5)
            {
                return ((Pulldisc() * (1 / 4)) + Pulldisc()) * CalcbasicCost();
            }
            else if (Role =="Student" && NumMuffins >3)
            {
                return ((Pulldisc() * (1 / 2) )+ Pulldisc()) * CalcbasicCost();
            }
            else
            {
                return Pulldisc() * CalcbasicCost();
            }
           
        } 

        //vat
        public double CalcVat()
        {
            return Pullvatrate() * CalcbasicCost();
        }

        //total
        public double CalcTotal()
        {
            return (CalcbasicCost() - CalcDiscount()) + CalcVat();
        }
    }
}