using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSO.Interfaces;
using PSO.Properties;
using PSO.DataModels;

namespace PSO.ViewModels
{
    public class SettingsDetailsViewModel : BindableBase
    {

        public SettingsDetailsViewModel()
        {
            AvailableFunctionTypes = new ValueDescriptionList<FunctionType>
                                        {
                                                new ValueDescription<FunctionType>(FunctionType.Rastrigin,              Resources.FunctionType_Rastrigin),
                                            new ValueDescription<FunctionType>(FunctionType.Ackley, Resources.FunctionType_Ackley)
                                        };
        }

        private FunctionType functionType = FunctionType.Rastrigin;

        public FunctionType FunctionType
        {
            get { return functionType; }
            set { SetProperty(ref functionType, value); }
        }

        public IValueDescriptionList<FunctionType> AvailableFunctionTypes { get; private set; }

    }
}
