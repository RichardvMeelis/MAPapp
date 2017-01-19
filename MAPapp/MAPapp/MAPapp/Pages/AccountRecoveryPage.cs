using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class AccountRecoveryPage : ContentPage
	{
        //Opent een webpagina in de app met daarin de accountrecovery pagina
		public AccountRecoveryPage ()
		{
            Content = new WebView()
            {
                Source = "https://apihost.nl/map/services/recovery.php"
            };
            
		}
	}
}
