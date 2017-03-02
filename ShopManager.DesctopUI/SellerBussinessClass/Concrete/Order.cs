using System;
using System.Collections.Generic;
using System.Linq;
using ShopManager.Model.Entities;
using ShopManager.DesctopUI.SellerBussinessClass.Abstraction;

namespace ShopManager.DesctopUI.SellerBussinessClass.Concrete
{
    /// <summary>
    /// Order class that represent order. Order can consist more than one realization record.
    /// </summary>
    internal class Order:IOrder
    {
        //I suppose that save realization record better in Dictionary , for better retrieval.
        private IDictionary<Guid, Realization> _relizDictionary;
        public Order()
        {
            _relizDictionary = new Dictionary<Guid,Realization>();
        }
        /// <summary>
        /// Add  product realization to  reliz Dictionary .
        /// </summary>
        /// <param name="product"> consist information about current Product.</param>
        /// <param name="empId">EmployeeId that try to  add new realization to dictionary.</param>
        /// <param name="quantity">How many we try to buy.</param>
        /// <returns>true: if succesuful operation.</returns>
        public bool Add(Product product,Guid empId,int quantity)
        {
           if(_relizDictionary.Keys.Contains(product.Id))
            {
                if (product.Quontity >= (quantity + _relizDictionary[product.Id].Quantity))
                {
                    _relizDictionary[product.Id].Quantity += quantity;
                    _relizDictionary[product.Id].Income += Convert.ToDecimal(quantity) * product.ActualPrice;
                    return true;
                }
                else
                {
                    return false;
                }
            }
           else
            {
                if (product.Quontity >= quantity)
                {
                    _relizDictionary.Add(product.Id,
                                new Realization()
                                {
                                    ProductId = product.Id,
                                    EmployeeId = empId,
                                    Quantity = quantity,
                                    Income = product.ActualPrice * Convert.ToDecimal(quantity)
                                });
                    return true;
                }
                else
                {
                    return false;
                }

            }
            
        }
        /// <summary>
        /// Delete product from dictionary.
        /// </summary>
        /// <param name="productId"> Id of the Product that we intend to delete. </param>
        /// <returns></returns>
        public bool Delete(Guid productId)
        {
           return _relizDictionary.Remove(productId);
        }
        public IEnumerable<Realization> ReturnRealizationList()
        {
            return this._relizDictionary.Values.ToList();
        }
        /// <summary>
        /// Check is dictionary empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if(_relizDictionary.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Count Order Total Sum(Realizations Incomes) 
        /// </summary>
        /// <returns> Calculated sum</returns>
        public decimal CountTotalSum()
        {
            decimal count =0 ;
            foreach (var item in _relizDictionary)
            {
                count += item.Value.Income;
            }
            return count;
        }
        /// <summary>
        /// Clear Realization Dictionary
        /// </summary>
        public void Clear()
        {
            _relizDictionary = new Dictionary<Guid, Realization>();
        }
    }
}
