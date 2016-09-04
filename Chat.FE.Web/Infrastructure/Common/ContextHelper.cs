using Chat.FE.Web.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Infrastructure.Common
{

    [ContractClass(typeof(ContextDataProviderClassContract))]
    public interface IContextDataProvider
    {
        string Login { get; set; }
        IHubContext HubContext { get; set; }
        string Room { get; set; }
        ContextData GetContextData();
    }


    public class ContextDataProvider : IContextDataProvider
    {

        private string _login;
        private IHubContext _hubContext;
        private string _room;

        public ContextDataProvider()
        {
            if (System.Web.HttpContext.Current?.Session != null)
            {
                _room = (System.Web.HttpContext.Current?.Session["room"].ToString()) ?? "";
            }

            if (System.Web.HttpContext.Current?.User != null)
            {
                _login = (System.Web.HttpContext.Current?.User.Identity.Name) ?? "";
            }
            
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<TechHub>();
            
        }

        public string Login
        {
            get { return string.IsNullOrEmpty(_login) ? System.Web.HttpContext.Current?.User.Identity.Name ?? "" : _login; }
            set { _login = value; }
        }

        public string Room
        {
            get { return string.IsNullOrEmpty(_room) ? System.Web.HttpContext.Current.Session["room"]?.ToString() ?? "" : _room; }
            set { this._room = value; }
        }

        public IHubContext HubContext
        {
            get { return _hubContext == null ? GlobalHost.ConnectionManager.GetHubContext<TechHub>() : _hubContext; }
            set { _hubContext = value; }
        }



        public ContextData GetContextData()
        {
            return new ContextData()
            {
                HubContext = _hubContext,
                Room = _room,
                Login = _login
            };
        }
    }

    public class ContextData
    {
        public string Room { get; set; }
        public IHubContext HubContext { get; set; }
        public string Login { get; set; }
    }

    #region code contract
    [ContractClassFor(typeof(IContextDataProvider))]
    public class ContextDataProviderClassContract : IContextDataProvider
    {
        public IHubContext HubContext
        {
            get; set;
        }

        public string Login { get; set; }
        public string Room { get; set; }

        public ContextData GetContextData()
        {
            Contract.Ensures(Contract.Result<ContextData>() != null);
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<ContextData>().Login));
            return default(ContextData);
        }
    }
    #endregion


}
