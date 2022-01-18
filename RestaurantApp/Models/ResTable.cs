using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class ResTable
    {
        public int Id;
        public int TableNumber;
        public int TableSize;
        public bool IsAvalabile;
        public int Seats;

        public ResTable (int _id , int _tableNumber , int _tableSize , bool _isasAvalabile , int _seats)
        {
            this.Id = _id;
            this.TableNumber = _tableNumber;
            this.TableSize = _tableSize;
            this.IsAvalabile = _isasAvalabile;
            this.Seats = _seats;
        }
        public ResTable () { }

    }
}