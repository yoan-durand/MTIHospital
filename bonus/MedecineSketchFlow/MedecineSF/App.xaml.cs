using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

//
// SketchFlow a besoin de savoir quel assembly de contrôle contient ses écrans. Ceci est défini automatiquement
// lors de la création du projet, mais si vous changez manuellement le nom de l'assembly de contrôle, vous devez aussi
// le mettre à jour manuellement ici.
//
[assembly: Microsoft.Expression.Prototyping.Services.SketchFlowLibraries("Test.Screens")]

namespace Test
{
	/// <summary>
	/// Logique d'interaction pour App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			this.Startup += this.App_Startup;
		}

		private void App_Startup(object sender, StartupEventArgs e)
		{
			this.StartupUri = new Uri(@"pack://application:,,,/Microsoft.Expression.Prototyping.Runtime;Component/WPF/Workspace/PlayerWindow.xaml");
		}
	}
}