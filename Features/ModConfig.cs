using BepInEx.Configuration;

namespace MoreTraders.Features
{
    public class ModConfig
    {
        public ConfigEntry<float> CustomTraderSpawnChance { get; }
        public ConfigEntry<bool> EnableMedic { get; }
        public ConfigEntry<bool> EnableChef { get; }
        public ConfigEntry<bool> EnableGambler { get; }

        public ModConfig(ConfigFile config)
        {
            CustomTraderSpawnChance = config.Bind(
                "Spawning",
                "CustomTraderSpawnChance",
                0.55f,
                "Chance (0.0 to 1.0) that a spawned trader will be one of the new types instead of a vanilla one."
            );

            EnableMedic = config.Bind(
                "Traders",
                "EnableMedic",
                true,
                "Enable Dr. Alistair the Medic."
            );

            EnableChef = config.Bind(
                "Traders",
                "EnableChef",
                true,
                "Enable Mama Cecile the Chef."
            );

            EnableGambler = config.Bind(
                "Traders",
                "EnableGambler",
                true,
                "Enable Jack the Dice the Gambler."
            );
        }
    }
}
