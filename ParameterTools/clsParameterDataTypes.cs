#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections;
#endregion // Namespaces

namespace OATools.ParameterTools
{
    public class clsParameterDataTypes
    {
        public static List<string> SP_dataTypes()
        {

            List<string> listOfDataTypes = new List<string>();

            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Angle.ToString());
            listOfDataTypes.Add(ParameterType.Area.ToString());
            listOfDataTypes.Add(ParameterType.AreaForce.ToString());
            listOfDataTypes.Add(ParameterType.AreaForcePerLength.ToString());
            listOfDataTypes.Add(ParameterType.BarDiameter.ToString());
            listOfDataTypes.Add(ParameterType.ColorTemperature.ToString());
            listOfDataTypes.Add(ParameterType.CrackWidth.ToString());
            listOfDataTypes.Add(ParameterType.Currency.ToString());
            listOfDataTypes.Add(ParameterType.DisplacementDeflection.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalApparentPower.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalCableTraySize.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalConduitSize.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalCurrent.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalDemandFactor.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalEfficacy.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalFrequency.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalIlluminance.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalLuminance.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalLuminousFlux.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalLuminousIntensity.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalPotential.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalPower.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalPowerDensity.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalResistivity.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalTemperature.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalTemperatureDifference.ToString());
            listOfDataTypes.Add(ParameterType.ElectricalWattage.ToString());
            listOfDataTypes.Add(ParameterType.Energy.ToString());
            listOfDataTypes.Add(ParameterType.FamilyType.ToString());
            listOfDataTypes.Add(ParameterType.FixtureUnit.ToString());
            listOfDataTypes.Add(ParameterType.Force.ToString());
            listOfDataTypes.Add(ParameterType.ForceLengthPerAngle.ToString());
            listOfDataTypes.Add(ParameterType.ForcePerLength.ToString());
            listOfDataTypes.Add(ParameterType.HVACAirflow.ToString());
            listOfDataTypes.Add(ParameterType.HVACAirflowDensity.ToString());
            listOfDataTypes.Add(ParameterType.HVACAirflowDividedByCoolingLoad.ToString());
            listOfDataTypes.Add(ParameterType.HVACAirflowDividedByVolume.ToString());
            listOfDataTypes.Add(ParameterType.HVACAreaDividedByCoolingLoad.ToString());
            listOfDataTypes.Add(ParameterType.HVACAreaDividedByHeatingLoad.ToString());
            listOfDataTypes.Add(ParameterType.HVACCoefficientOfHeatTransfer.ToString());
            listOfDataTypes.Add(ParameterType.HVACCoolingLoad.ToString());
            listOfDataTypes.Add(ParameterType.HVACCoolingLoadDividedByArea.ToString());
            listOfDataTypes.Add(ParameterType.HVACCoolingLoadDividedByVolume.ToString());
            listOfDataTypes.Add(ParameterType.HVACCrossSection.ToString());
            listOfDataTypes.Add(ParameterType.HVACDensity.ToString());
            listOfDataTypes.Add(ParameterType.HVACDuctInsulationThickness.ToString());
            listOfDataTypes.Add(ParameterType.HVACDuctLiningThickness.ToString());
            listOfDataTypes.Add(ParameterType.HVACDuctSize.ToString());
            listOfDataTypes.Add(ParameterType.HVACEnergy.ToString());
            listOfDataTypes.Add(ParameterType.HVACFactor.ToString());
            listOfDataTypes.Add(ParameterType.HVACFriction.ToString());
            listOfDataTypes.Add(ParameterType.HVACHeatGain.ToString());
            listOfDataTypes.Add(ParameterType.HVACHeatingLoad.ToString());
            listOfDataTypes.Add(ParameterType.HVACHeatingLoadDividedByArea.ToString());
            listOfDataTypes.Add(ParameterType.HVACHeatingLoadDividedByVolume.ToString());
            listOfDataTypes.Add(ParameterType.HVACPermeability.ToString());
            listOfDataTypes.Add(ParameterType.HVACPower.ToString());
            listOfDataTypes.Add(ParameterType.HVACPowerDensity.ToString());
            listOfDataTypes.Add(ParameterType.HVACPressure.ToString());
            listOfDataTypes.Add(ParameterType.HVACRoughness.ToString());
            listOfDataTypes.Add(ParameterType.HVACSlope.ToString());
            listOfDataTypes.Add(ParameterType.HVACSpecificHeat.ToString());
            listOfDataTypes.Add(ParameterType.HVACSpecificHeatOfVaporization.ToString());
            listOfDataTypes.Add(ParameterType.HVACTemperature.ToString());
            listOfDataTypes.Add(ParameterType.HVACTemperatureDifference.ToString());
            listOfDataTypes.Add(ParameterType.HVACThermalConductivity.ToString());
            listOfDataTypes.Add(ParameterType.HVACThermalMass.ToString());
            listOfDataTypes.Add(ParameterType.HVACThermalResistance.ToString());
            listOfDataTypes.Add(ParameterType.HVACVelocity.ToString());
            listOfDataTypes.Add(ParameterType.HVACViscosity.ToString());
            listOfDataTypes.Add(ParameterType.Image.ToString());
            listOfDataTypes.Add(ParameterType.Integer.ToString());
            listOfDataTypes.Add(ParameterType.Invalid.ToString());
            listOfDataTypes.Add(ParameterType.Length.ToString());
            listOfDataTypes.Add(ParameterType.LinearForce.ToString());
            listOfDataTypes.Add(ParameterType.LinearForceLengthPerAngle.ToString());
            listOfDataTypes.Add(ParameterType.LinearForcePerLength.ToString());
            listOfDataTypes.Add(ParameterType.LinearMoment.ToString());
            listOfDataTypes.Add(ParameterType.LoadClassification.ToString());
            listOfDataTypes.Add(ParameterType.Mass.ToString());
            listOfDataTypes.Add(ParameterType.MassDensity.ToString());
            listOfDataTypes.Add(ParameterType.MassPerUnitArea.ToString());
            listOfDataTypes.Add(ParameterType.MassPerUnitLength.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());
            listOfDataTypes.Add(ParameterType.Acceleration.ToString());


            return listOfDataTypes;

        }

    }
}
