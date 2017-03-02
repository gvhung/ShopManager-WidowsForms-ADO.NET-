using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;

namespace ShopManager.DesctopUI.ManagerBussinessClass.Concrete
{
    public class CustomCategories
    {
        private bool _isSetted = false;
        private IDictionary<Category, IEnumerable<SubCategory>> _categoryDictionary;
        public CustomCategories()
        {
            _categoryDictionary = new Dictionary<Category, IEnumerable<SubCategory>>();
        }
        public void FillCategoryDictionary()
        {
            var categoryList = Manager.Instance.UnitOfWork.CategoryRepository.GetAllCategory();
            foreach (var item in categoryList)
            {
                _categoryDictionary.Add(item, Manager.Instance.UnitOfWork.SubCategoryRepository.GetSubCategoryByCategoryId(item.Id));
            }
            _isSetted = true;
        }
        public IDictionary<Category, IEnumerable<SubCategory>> CategoryDictionary
        {
            get
            {
                if(_isSetted)
                {
                    return _categoryDictionary;
                }
                else
                {
                    FillCategoryDictionary();
                    return _categoryDictionary;
                }
            }
        }
    }
}
