using System.Collections.Generic;
using System.Linq;
using GameDatabase.DataModel;
using GameDatabase.Model;

namespace Database.Legacy
{
    public static class LegacyComponentNames
    {
        public static ItemId<Component> GetId(string value) { int id; return new ItemId<Component>(_items.TryGetValue(value, out id) ? id : -1); }

        public static string GetName(ItemId<Component> id) { return _items.FirstOrDefault(item => item.Value == id.Value).Key; } // TODO: delete

        private static readonly Dictionary<string, int> _items = new Dictionary<string, int>()
        {
            { "Afterburner", 0 },
            { "EnergyAbsorber_L", 1 },
            { "EnergyAbsorber_M", 2 },
            { "EnergyAbsorber_S", 3 },
            { "ImpactArmor_L", 4 },
            { "ImpactArmor_M", 5 },
            { "ImpactArmor_S", 6 },
            { "ThermalArmor_L", 7 },
            { "ThermalArmor_M", 8 },
            { "ThermalArmor_S", 9 },
            { "TitaniumArmor_L", 10 },
            { "TitaniumArmor_M", 11 },
            { "TitaniumArmor_S", 12 },
            { "DroneBay_L_0", 13 },
            { "DroneBay_L_1", 14 },
            { "DroneBay_L_3", 15 },
            { "DroneBay_L_4", 16 },
            { "DroneBay_L_5", 17 },
            { "DroneBay_L_6", 18 },
            { "DroneBay_L_7", 19 },
            { "LaserBeam_L_1", 20 },
            { "LightningCannon_L_1", 21 },
            { "PulseCannon_L_1", 22 },
            { "StasisField_L_1", 23 },
            { "StasisField_L_2", 24 },
            { "Teleporter_Boss1", 25 },
            { "Teleporter_X", 26 },
            { "VampiricRay_L", 27 },
            { "CloakingSystem", 28 },
            { "StealthField", 29 },
            { "SuperStealthField", 30 },
            { "Detonator_M", 31 },
            { "DroneBay_M_11", 32 },
            { "DroneBay_M_21", 33 },
            { "DroneBay_M_22", 34 },
            { "DroneBay_M_31", 35 },
            { "DroneBay_M_41", 36 },
            { "DroneBay_M_51", 37 },
            { "DroneBay_M_54", 38 },
            { "DroneBay_M_81", 39 },
            { "DroneBay_M_A1", 40 },
            { "DroneBay_S_11", 41 },
            { "DroneBay_S_21", 42 },
            { "DroneBay_S_22", 43 },
            { "DroneBay_S_31", 44 },
            { "DroneBay_S_41", 45 },
            { "DroneBay_S_51", 46 },
            { "DroneBay_S_54", 47 },
            { "DroneBay_S_81", 48 },
            { "DroneBay_S_A1", 49 },
            { "DroneControlUnit", 50 },
            { "DroneDamageAmplifier", 51 },
            { "DroneFactory", 52 },
            { "DroneNavigationComputer", 53 },
            { "EcmJammer", 54 },
            { "FusionDrive_L", 55 },
            { "FusionDrive_M", 56 },
            { "FusionDrive_S", 57 },
            { "NuclearDrive_L", 58 },
            { "NuclearDrive_M", 59 },
            { "NuclearDrive_S", 60 },
            { "NuclearDrive_T", 61 },
            { "ArmoredFuelCell_L", 62 },
            { "ArmoredFuelCell_M", 63 },
            { "ArmoredFuelCell_S", 64 },
            { "FuelCell_L", 65 },
            { "FuelCell_M", 66 },
            { "FuelCell_S", 67 },
            { "GravityGenerator", 68 },
            { "InertialDamper", 69 },
            { "InertialNullifier", 70 },
            { "InertialStabilizer", 71 },
            { "Nanofiber", 72 },
            { "PointDefense", 73 },
            { "AntiMatterReactor", 74 },
            { "AntiMatterReactor_L", 75 },
            { "NuclearReactor_L", 76 },
            { "NuclearReactor_M", 77 },
            { "NuclearReactor_S", 78 },
            { "RepairBot_M", 79 },
            { "RepairBot_S", 80 },
            { "EnergyShield", 83 },
            { "FrontalShield", 84 },
            { "TestLaserBeam", 85 },
            { "TutorialDrive", 86 },
            { "TutorialGun", 87 },
            { "TutorialMissile", 88 },
            { "BrakingSystem", 89 },
            { "FortificationSystem", 90 },
            { "TargetingUnit", 91 },
            { "Teleporter", 92 },
            { "AcidCannon_M_1", 93 },
            { "BlackHole_M_1", 94 },
            { "FragBomb_M_1", 95 },
            { "XmasBomb_M_1", 96 },
            { "DroneControl_M", 97 },
            { "EnergyBeam_M", 98 },
            { "EnergySiphon_M", 99 },
            { "EnergySiphon_S", 100 },
            { "TractorBeam_M", 101 },
            { "VampiricRay_L_1", 102 },
            { "VampiricRay_M", 103 },
            { "VampiricRay_M_1", 104 },
            { "MassDriver_M_1", 105 },
            { "MassDriver_M_2", 106 },
            { "NeutronBlaster_L_1", 107 },
            { "NeutronBlaster_M_1", 108 },
            { "NeutronBlaster_M_2", 109 },
            { "PlasmaCannon_S_1", 110 },
            { "PulseCannon_L_2", 111 },
            { "PulseCannon_M_1", 112 },
            { "PulseCannon_M_2", 113 },
            { "PulseCannon_S_1", 114 },
            { "PulseCannon_S_2", 115 },
            { "RailGun_L_1", 116 },
            { "ChargedLaser_L_1", 117 },
            { "ChargedLaser_L_2", 118 },
            { "ChargedLaser_L_3", 119 },
            { "LaserBeam_L_2", 120 },
            { "LaserBeam_M_1", 121 },
            { "LaserBeam_S_1", 122 },
            { "LaserBeam_S_2", 123 },
            { "LaserCannon_M_1", 124 },
            { "LightningCannon_M_1", 125 },
            { "LightningCannon_S_1", 126 },
            { "LightningCannon_S_2", 127 },
            { "LightningCannon_S_3", 128 },
            { "PulseMashineGun_M_1", 129 },
            { "MissileLauncher_L_1", 130 },
            { "MissileLauncher_L_2", 131 },
            { "MissileLauncher_L_3", 132 },
            { "MissileLauncher_M_1", 133 },
            { "MissileLauncher_M_2", 134 },
            { "MissileLauncher_S_1", 135 },
            { "PlasmaThrower_M_1", 136 },
            { "PlasmaThrower_M_2", 137 },
            { "AntiMatterBomb_L_1", 138 },
            { "AntiMatterBomb_L_2", 139 },
            { "Pulsar_M_1", 140 },
            { "Pulsar_M_2", 141 },
            { "PlasmaMultiCannon_M_1", 142 },
            { "PulseMultiCannon_M_1", 143 },
            { "SingularityCannon_M_1", 144 },
            { "RepairBeam_S_1", 145 },
            { "StasisField_M_1", 146 },
            { "StasisField_S_1", 147 },
            { "ChargedTorpedo_L_1", 148 },
            { "EmpTorpedo_M_1", 149 },
            { "PlasmaTorpedo_L_1", 150 },
            { "ProtoonTorpedo_L_1", 151 },
            { "ProtoonTorpedo_M_1", 152 },
            { "ProtoonTorpedo_M_2", 153 },
            { "ProtoonTorpedo_S_1", 154 },
            { "QuantumTorpedo_L_1", 155 },
            { "AutomatedReloader_M", 156 },
            { "AutomatedReloader_S", 157 },
            { "HighEnergyFocus_M", 158 },
            { "HighEnergyFocus_S", 159 },
            { "RangemasterUnit_M", 160 },
            { "ChargedLaser_M_1", 161 },
            { "PlasmaWeb_M_1", 162 },
            { "PlasmaWeb_S_1", 163 },
            { "EmpTorpedo_L_1", 164 },
            { "RocketLauncher_M_1", 165 },
            { "RocketLauncher_M_2", 166 },
            { "IonCannon_M_1", 167 },
            { "IonCannon_L_1", 168 },
            { "IonCannon_L_2", 169 },
            { "IonCannon_M_2", 170 },
            { "RepairBeam_M_1", 171 },
            { "DroneBay_S_91", 172 },
            { "MissileLauncher_M_3", 173 },
            { "AcidMissileLauncher_L_1", 174 },
            { "MissileLauncher_L_4", 175 },
            { "ShieldGenerator_M", 176 },
            { "ShieldGenerator_L", 177 },
            { "ShieldGenerator_S", 178 },
            { "ShieldCapacitor_L", 179 },
            { "ShieldCapacitor_M", 180 },
            { "ShieldCapacitor_S", 181 },
            { "DroneControlUnit_L", 182 },
            { "DroneControlUnit_M", 183 },
            { "DroneDamageAmplifier_L", 184 },
            { "DroneDamageAmplifier_M", 185 },
            { "DroneFactory_L", 186 },
            { "DroneFactory_M", 187 },
            { "DroneNavigationComputer_L", 188 },
            { "DroneNavigationComputer_M", 189 },
            { "DroneDefense_L", 190 },
            { "DroneDefense_M", 191 },
            { "DroneDefense_S", 192 },
            { "DroneEngine_1", 196 },
            { "DroneArmor_1", 197 },
            { "DroneEngine_2", 198 },
            { "DroneBay_L_11", 204 },
            { "DroneBay_L_21", 205 },
            { "DroneBay_L_22", 206 },
            { "DroneBay_L_31", 207 },
            { "DroneBay_L_41", 208 },
            { "DroneBay_L_51", 209 },
            { "DroneBay_L_54", 210 },
            { "DroneBay_L_81", 211 },
            { "DroneBay_L_A1", 212 },
        };
    }
}
