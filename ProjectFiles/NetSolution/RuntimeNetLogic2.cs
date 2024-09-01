#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
#endregion

public class RuntimeNetLogic2 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
       
        var myVar = Project.Current.GetVariable("Model/Variable1");
        
        myVar.VariableChange += MyVar_VariableChange;
        
        
        
    }

     private void MyVar_VariableChange(object sender, VariableChangeEventArgs e) {
        try {
           
            var myDialog = InformationModel.Get<DialogType>(LogicObject.GetVariable("DialogValue1").Value);
            Log.Info("Dialogname: " + e.NewValue.Value.ToString());
            UICommands.OpenDialog((Window)Owner, myDialog);
        } catch {
            Log.Warning("No corresponding DialogBox for value: " + e.NewValue.ToString());
        }
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
