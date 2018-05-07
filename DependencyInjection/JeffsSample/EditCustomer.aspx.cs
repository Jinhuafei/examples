using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeffsSample
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        public EditCustomer(ICustomerRepository repo)
        {
            _customerRepository = repo;
        }

        private ICustomerRepository _customerRepository;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}