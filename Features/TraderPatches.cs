using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MoreTraders.Features
{
    [HarmonyPatch]
    public static class TraderPatches
    {
        // Set dialogue helpers
        private static void SetLines(Dictionary<string, List<string>> dict, string key, params string[] lines)
        {
            dict[key] = new List<string>(lines);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Locale), nameof(Locale.LoadLanguage))]
        public static void PostfixLoadLanguage()
        {
            if (Locale.currentLang == null || Locale.currentLang.character == null)
            {
                return;
            }

            var originalArray = Locale.currentLang.character;
            int originalLength = originalArray.Length;

            if (originalLength < 10)
            {
                var newArray = new Dictionary<string, List<string>>[10];
                for (int i = 0; i < originalLength; i++)
                {
                    newArray[i] = originalArray[i];
                }
                for (int i = originalLength; i < 10; i++)
                {
                    newArray[i] = new Dictionary<string, List<string>>();
                }
                Locale.currentLang.character = newArray;
            }

            Plugin.Logger.LogInfo("MoreTraders: Dynamically resized character dialogue array to 10.");

            // ----------------------------------------------------
            // DR. ALISTAIR (Medic - Character 4)
            // ----------------------------------------------------
            var medicDict = Locale.currentLang.character[4];
            SetLines(medicDict, "tradermeetnormal", 
                "State your symptoms, survivor. I am Alistair. Let's keep this professional.",
                "Need medical aid? I have clean supplies, for a price."
            );
            SetLines(medicDict, "tradermeetgood", 
                "Ah, looking relatively healthy today! How can I help you?",
                "Good to see you, my friend. What's ailing you?"
            );
            SetLines(medicDict, "tradermeetbad", 
                "You look terrible. Please don't contaminate my surgical area.",
                "If you're here to die, do it outside."
            );
            SetLines(medicDict, "tradermeetimpairedspeech", "Speech motor centers damaged? Let's use simple trade gestures, then.");
            SetLines(medicDict, "traderseehurt", "You are bleeding heavily. Lie down, let me see to those wounds!");
            SetLines(medicDict, "traderseegun", "Put that firearm away. A surgeon's hands must remain steady.");
            SetLines(medicDict, "traderbuy", 
                "Excellent choice. Apply that carefully.",
                "That should keep you upright for a while."
            );
            SetLines(medicDict, "traderbuyfail", "I cannot give out life-saving medicine for free.");
            SetLines(medicDict, "traderbuyfailmaxvalue", "My medical inventory is strictly accounted for. I can't take any more junk.");
            SetLines(medicDict, "tradergiveitem", "This is a useful specimen or component. I'll credit you.");
            SetLines(medicDict, "tradergiveitemrefuse", "I have no clinical use for this.");
            SetLines(medicDict, "traderhagglesuccess", "Hmph. I suppose I can adjust the consultation fee slightly.");
            SetLines(medicDict, "traderhagglefail", "Medical pricing is non-negotiable. Don't risk your health haggling.");
            SetLines(medicDict, "traderhugsuccess", "Well... personal touch is indeed therapeutic. Thank you.");
            SetLines(medicDict, "traderhugfail", "Social distancing is critical for infection control! Stay back!");
            SetLines(medicDict, "tradermove", "Very well. I will relocate my medical station.");
            SetLines(medicDict, "tradermovefail", "I cannot move this sterile field right now.");
            SetLines(medicDict, "traderthreatensuccess", "Fine! Take the supplies, just don't damage the medical equipment!");
            SetLines(medicDict, "traderwarning", "Hostile behavior will result in immediate termination. Back off.");
            SetLines(medicDict, "tradercombat", "I know exactly where to strike to cause maximum hemorrhaging!");
            SetLines(medicDict, "traderlightbreak", "You broke my surgical light! My precision is ruined!");
            SetLines(medicDict, "traderwakegreet", "Waking up? Good. Your vitals seem stable.");

            // ----------------------------------------------------
            // MAMA CECILE (Chef - Character 5)
            // ----------------------------------------------------
            var chefDict = Locale.currentLang.character[5];
            SetLines(chefDict, "tradermeetnormal", 
                "Smells like hunger! Come in, sweetie, Mama Cecile has got some hot food for you.",
                "Ooh, you look like you need a warm bowl of soup, dear."
            );
            SetLines(chefDict, "tradermeetgood", 
                "There's my favorite customer! I cooked up something special today!",
                "Welcome back, dear! Ready for some real food?"
            );
            SetLines(chefDict, "tradermeetbad", "Oh honey, you're looking thin as a rail! Let me feed you before you collapse!");
            SetLines(chefDict, "tradermeetimpairedspeech", "Oh, poor thing, too hungry to speak? Here, just point to what you want.");
            SetLines(chefDict, "traderseehurt", "Oh dear, those are nasty cuts! Let's get some clean dressings on you.");
            SetLines(chefDict, "traderseegun", "Put that toy away, sweetie. You'll spoil your appetite.");
            SetLines(chefDict, "traderbuy", 
                "Eat up, dear! It's made with love.",
                "Enjoy! Come back if you're still hungry."
            );
            SetLines(chefDict, "traderbuyfail", "I'd love to feed you, sweetie, but Mama needs to buy ingredients too!");
            SetLines(chefDict, "traderbuyfailmaxvalue", "My cupboards are full, dear! I can't store any more of your knick-knacks.");
            SetLines(chefDict, "tradergiveitem", "Ooh, this looks like a wonderful ingredient! Thank you, dear.");
            SetLines(chefDict, "tradergiveitemrefuse", "No, no, that's far too dirty to put in my kitchen!");
            SetLines(chefDict, "traderhagglesuccess", "Alright, just because you reminded me of my grandkid, I'll give you a discount!");
            SetLines(chefDict, "traderhagglefail", "Mama's gotta make a living too, sweetie! No more discounts.");
            SetLines(chefDict, "traderhugsuccess", "Bring it in, sweetie! A warm hug makes everything taste better!");
            SetLines(chefDict, "traderhugfail", "Oh, stay back, dear! You're covered in soot! Wash up first.");
            SetLines(chefDict, "tradermove", "Alright, sweetie, let me pack up my pots and pans.");
            SetLines(chefDict, "tradermovefail", "My stew is simmering, I can't move the stove right now!");
            SetLines(chefDict, "traderthreatensuccess", "Oh my, please don't hurt me! Take whatever you want from the pantry!");
            SetLines(chefDict, "traderwarning", "Don't make Mama get her rolling pin out, dear.");
            SetLines(chefDict, "tradercombat", "I've chopped up tougher meat than you for my stew!");
            SetLines(chefDict, "traderlightbreak", "Hey! Cooking in the dark is how people lose fingers!");
            SetLines(chefDict, "traderwakegreet", "Morning, sunshine! Breakfast is almost ready.");

            // ----------------------------------------------------
            // JACK THE DICE (Gambler - Character 6)
            // ----------------------------------------------------
            var gamblerDict = Locale.currentLang.character[6];
            SetLines(gamblerDict, "tradermeetnormal", 
                "Looking to make a deal? Let's see what the dice say today.",
                "Ah, another player in the wasteland. Want to test your luck?"
            );
            SetLines(gamblerDict, "tradermeetgood", 
                "Hey! The high roller returns! What's the play today, partner?",
                "Good to see you! Ready to double down?"
            );
            SetLines(gamblerDict, "tradermeetbad", "Hmph. You look like you're on a losing streak. Hope your luck turns around.");
            SetLines(gamblerDict, "tradermeetimpairedspeech", "Can't talk? No problem. Money talks, cards whisper. Show me what you've got.");
            SetLines(gamblerDict, "traderseehurt", "Woah, you're bleeding all over my table! That's bad luck.");
            SetLines(gamblerDict, "traderseegun", "Whoa, keep the iron in its holster. Let's keep this friendly.");
            SetLines(gamblerDict, "traderbuy", 
                "A winning bet! Here's your prize.",
                "Pleasure doing business with a fellow gamer."
            );
            SetLines(gamblerDict, "traderbuyfail", "No free rides at this table, partner. Cash only.");
            SetLines(gamblerDict, "traderbuyfailmaxvalue", "House limits, partner. I can't take any more of this junk.");
            SetLines(gamblerDict, "tradergiveitem", "Nice item. I'll give you some chips for it.");
            SetLines(gamblerDict, "tradergiveitemrefuse", "That's a bust. I'm not taking that junk.");
            SetLines(gamblerDict, "traderhagglesuccess", "Double or nothing! You win this round, partner. Here's your discount.");
            SetLines(gamblerDict, "traderhagglefail", "Snake eyes! The house always wins, partner. No discount.");
            SetLines(gamblerDict, "traderhugsuccess", "Haha! You're a wildcard, aren't you? Alright, bring it in.");
            SetLines(gamblerDict, "traderhugfail", "Whoa, whoa! Personal space, buddy! I don't do hugs.");
            SetLines(gamblerDict, "tradermove", "Alright, folding this table. Let's set up elsewhere.");
            SetLines(gamblerDict, "tradermovefail", "Can't fold right now, the game's in progress.");
            SetLines(gamblerDict, "traderthreatensuccess", "Whoa, cool it! No need to get physical. Take the pot, take it!");
            SetLines(gamblerDict, "traderwarning", "Cheaters and sore losers get dealt with. Back off.");
            SetLines(gamblerDict, "tradercombat", "Time to cash in your chips, pal!");
            SetLines(gamblerDict, "traderlightbreak", "Hey! No turning off the lights at the casino!");
            SetLines(gamblerDict, "traderwakegreet", "Waking up? Let's roll for initiative.");

            Plugin.Logger.LogInfo("MoreTraders: Successfully injected all custom dialogue strings into active language.");
        }

        private static void SpawnTraderInstance(int type, Vector2 pos)
        {
            GameObject traderObj = Utils.Create("trader1", pos, 0f);
            if (traderObj != null)
            {
                var script = traderObj.GetComponent<TraderScript>();
                if (script != null)
                {
                    script.character = type;
                    CustomizeAesthetics(script);
                    script.GenerateInventory();
                    
                    string name = type switch
                    {
                        1 => "Gunsmith",
                        2 => "Cannibal",
                        3 => "General merchant",
                        4 => "Dr. Alistair (Medic)",
                        5 => "Mama Cecile (Chef)",
                        6 => "Jack the Dice (Gambler)",
                        _ => "Unknown"
                    };
                    Plugin.Logger.LogInfo($"MoreTraders: Spawned {name} (Type {type}) at {pos}");
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ConsoleScript), "Start")]
        public static void PostfixConsoleStart()
        {
            var spawntraderAutofill = new Dictionary<int, List<string>>
            {
                { 0, new List<string> { "1", "2", "3", "4", "5", "6" } },
                { 1, new List<string> { "player", "cursor" } }
            };

            var singleTraderAutofill = new Dictionary<int, List<string>>
            {
                { 0, new List<string> { "player", "cursor" } }
            };

            // Inject spawntrader command
            ConsoleScript.Commands.Add(new Command("spawntrader", "Spawns a specific trader (1-6) at the cursor or player.", delegate(string[] args)
            {
                if (args.Length < 2)
                {
                    ConsoleScript.instance.Alert("Usage: spawntrader <1-6> [position: cursor/player]");
                    return;
                }

                if (!int.TryParse(args[1], out int type) || type < 1 || type > 6)
                {
                    ConsoleScript.instance.Alert("Trader type must be between 1 and 6!");
                    return;
                }

                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (args.Length > 2)
                {
                    if (args[2].ToLower() == "player" && PlayerCamera.main != null)
                    {
                        pos = PlayerCamera.main.body.transform.position;
                    }
                }

                SpawnTraderInstance(type, pos);
            }, spawntraderAutofill, ("int type", "Trader type: 1-3 vanilla, 4 = Medic, 5 = Chef, 6 = Gambler"), ("string pos", "Optional: 'player' or 'cursor' (default)")));

            // Inject spawnmedic command
            ConsoleScript.Commands.Add(new Command("spawnmedic", "Spawns Dr. Alistair (Medic) at the cursor or player.", delegate(string[] args)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (args.Length > 1 && args[1].ToLower() == "player" && PlayerCamera.main != null)
                {
                    pos = PlayerCamera.main.body.transform.position;
                }
                SpawnTraderInstance(4, pos);
            }, singleTraderAutofill, ("string pos", "Optional: 'player' or 'cursor' (default)")));

            // Inject spawnchef command
            ConsoleScript.Commands.Add(new Command("spawnchef", "Spawns Mama Cecile (Chef) at the cursor or player.", delegate(string[] args)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (args.Length > 1 && args[1].ToLower() == "player" && PlayerCamera.main != null)
                {
                    pos = PlayerCamera.main.body.transform.position;
                }
                SpawnTraderInstance(5, pos);
            }, singleTraderAutofill, ("string pos", "Optional: 'player' or 'cursor' (default)")));

            // Inject spawngambler command
            ConsoleScript.Commands.Add(new Command("spawngambler", "Spawns Jack the Dice (Gambler) at the cursor or player.", delegate(string[] args)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (args.Length > 1 && args[1].ToLower() == "player" && PlayerCamera.main != null)
                {
                    pos = PlayerCamera.main.body.transform.position;
                }
                SpawnTraderInstance(6, pos);
            }, singleTraderAutofill, ("string pos", "Optional: 'player' or 'cursor' (default)")));

            Plugin.Logger.LogInfo("MoreTraders: Registered all trader spawn console commands with autocomplete.");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TraderScript), "Start")]
        public static void PostfixTraderStart(TraderScript __instance)
        {
            // Only randomize if we are a vanilla trader (1, 2, or 3) and hasn't been randomized yet
            if (__instance.character >= 1 && __instance.character <= 3)
            {
                float roll = UnityEngine.Random.value;
                if (roll < Plugin.Cfg.CustomTraderSpawnChance.Value)
                {
                    // Select an enabled custom trader type
                    var availableTraders = new List<int>();
                    if (Plugin.Cfg.EnableMedic.Value) availableTraders.Add(4);
                    if (Plugin.Cfg.EnableChef.Value) availableTraders.Add(5);
                    if (Plugin.Cfg.EnableGambler.Value) availableTraders.Add(6);

                    if (availableTraders.Count > 0)
                    {
                        int selectedType = availableTraders[UnityEngine.Random.Range(0, availableTraders.Count)];
                        __instance.character = selectedType;

                        CustomizeAesthetics(__instance);
                        __instance.GenerateInventory(); // Regenerate inventory with the new type

                        Plugin.Logger.LogInfo($"MoreTraders: Converted spawned trader into Type {selectedType}.");
                    }
                }
            }
        }

        private static void CustomizeAesthetics(TraderScript trader)
        {
            var headRenderer = trader.head.GetComponent<SpriteRenderer>();
            var torsoRenderer = trader.torso.GetComponent<SpriteRenderer>();
            var lArmRenderer = trader.lArm.GetComponent<SpriteRenderer>();
            var rArmRenderer = trader.rArm.GetComponent<SpriteRenderer>();
            var lThighRenderer = trader.lThigh.GetComponent<SpriteRenderer>();
            var rThighRenderer = trader.rThigh.GetComponent<SpriteRenderer>();
            var lFootRenderer = trader.lFoot.GetComponent<SpriteRenderer>();
            var rFootRenderer = trader.rFoot.GetComponent<SpriteRenderer>();

            var build = trader.GetComponent<BuildingEntity>();

            if (trader.character == 4) // Dr. Alistair (Medic - White lab coat, navy pants, black boots)
            {
                torsoRenderer.color = Color.white;
                lArmRenderer.color = Color.white;
                rArmRenderer.color = Color.white;
                lThighRenderer.color = new Color(0.18f, 0.28f, 0.46f);
                rThighRenderer.color = new Color(0.18f, 0.28f, 0.46f);
                lFootRenderer.color = Color.black;
                rFootRenderer.color = Color.black;
                trader.heightMult = 1.12f;

                if (build != null)
                {
                    build.fullName = "Dr. Alistair (Medic)";
                    build.description = "A meticulous, weary field surgeon offering sterile medical supplies and treatments.";
                }
            }
            else if (trader.character == 5) // Mama Cecile (Chef - Pink dress, warm apron, brown shoes, petite)
            {
                torsoRenderer.color = new Color(0.92f, 0.44f, 0.60f);
                lArmRenderer.color = new Color(0.92f, 0.44f, 0.60f);
                rArmRenderer.color = new Color(0.92f, 0.44f, 0.60f);
                lThighRenderer.color = new Color(0.28f, 0.28f, 0.28f);
                rThighRenderer.color = new Color(0.28f, 0.28f, 0.28f);
                lFootRenderer.color = new Color(0.44f, 0.22f, 0.11f);
                rFootRenderer.color = new Color(0.44f, 0.22f, 0.11f);
                trader.heightMult = 0.85f;

                if (build != null)
                {
                    build.fullName = "Mama Cecile (Chef)";
                    build.description = "A warm, eccentric grandmother cooking nourishing meals and trading food ingredients.";
                }
            }
            else if (trader.character == 6) // Jack the Dice (Gambler - Purple jacket, charcoal pants, shiny gold buckles)
            {
                torsoRenderer.color = new Color(0.44f, 0.14f, 0.53f);
                lArmRenderer.color = new Color(0.44f, 0.14f, 0.53f);
                rArmRenderer.color = new Color(0.44f, 0.14f, 0.53f);
                lThighRenderer.color = new Color(0.18f, 0.18f, 0.18f);
                rThighRenderer.color = new Color(0.18f, 0.18f, 0.18f);
                lFootRenderer.color = new Color(0.88f, 0.72f, 0.08f);
                rFootRenderer.color = new Color(0.88f, 0.72f, 0.08f);
                trader.heightMult = 1.0f;

                if (build != null)
                {
                    build.fullName = "Jack the Dice (Gambler)";
                    build.description = "A slick scrapper and card dealer who trades tech containers and loves a high-stakes roll.";
                }
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(TraderScript), nameof(TraderScript.GenerateInventory))]
        public static bool PrefixGenerateInventory(TraderScript __instance)
        {
            if (__instance.character >= 4)
            {
                __instance.items = new List<TraderItem>();
                int amount = Mathf.RoundToInt(UnityEngine.Random.Range(4f, 9f) * WorldGeneration.GetRunSettingFloat("traderitemamount"));

                if (__instance.character == 5) amount = Mathf.RoundToInt(amount * 1.25f); // Mama Cecile has more food items
                if (__instance.character == 6) amount = Mathf.RoundToInt(amount * 0.9f); // Jack the Dice has slightly fewer items

                string[] categories = __instance.character switch
                {
                    4 => new[] { "medical", "drug", "water" },
                    5 => new[] { "food", "water" },
                    6 => new[] { "tool", "container", "utility", "custom" },
                    _ => new[] { "medical", "food", "water", "tool", "drug", "container", "utility", "custom" }
                };

                for (int i = 0; i < amount; i++)
                {
                    string category = categories[UnityEngine.Random.Range(0, categories.Length)];
                    var tuple = ItemLootPool.RandomFromPool(category);
                    if (tuple.Item2 != null && tuple.Item2.value > 0)
                    {
                        TraderScript.TraderItemPreference pref = (TraderScript.TraderItemPreference)UnityEngine.Random.Range(0, 3);
                        __instance.items.Add(new TraderItem
                        {
                            id = tuple.Item1,
                            preference = pref,
                            bought = false,
                            value = tuple.Item2.DefaultValue()
                        });
                    }
                }

                // Sort by preference (same sorting as vanilla)
                __instance.items = __instance.items.OrderBy(x => (int)x.preference).ToList();

                return false; // skip default generation
            }
            return true; // run vanilla generation for 1, 2, 3
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(TraderScript), nameof(TraderScript.TryHaggle))]
        public static bool PrefixTryHaggle(TraderScript __instance)
        {
            if (__instance.character == 6) // Jack the Dice's gambling roll
            {
                int playerRoll = UnityEngine.Random.Range(1, 7);
                int houseRoll = UnityEngine.Random.Range(1, 7);

                if (playerRoll > houseRoll)
                {
                    float num = UnityEngine.Random.Range(18f, 32f);
                    __instance.reputation += num;
                    __instance.talker.Talk($"[Rolled {playerRoll} vs {houseRoll}] " + Locale.GetCharacter("traderhagglesuccess", 6).PickRandom());
                    
                    if (PlayerCamera.main.body != null)
                    {
                        PlayerCamera.main.body.skills.AddExp(2, 4f);
                    }
                    PlayerCamera.main.PlayUISound(PlayerCamera.UISoundType.Click);
                }
                else if (playerRoll < houseRoll)
                {
                    float num = UnityEngine.Random.Range(10f, 18f);
                    __instance.reputation -= num;
                    __instance.talker.Talk($"[Rolled {playerRoll} vs {houseRoll}] " + Locale.GetCharacter("traderhagglefail", 6).PickRandom());
                    PlayerCamera.main.PlayUISound(PlayerCamera.UISoundType.Deny);
                }
                else // Tie!
                {
                    __instance.talker.Talk($"[Rolled {playerRoll} vs {houseRoll}] Push! A tie goes to the house, partner, but I won't lower your standing.");
                    PlayerCamera.main.PlayUISound(PlayerCamera.UISoundType.MiniClick);
                }

                PlayerCamera.main.UpdateTradeTexts();
                PlayerCamera.main.RefreshTraderInventories();
                return false; // Skip vanilla haggle/bite
            }
            return true; // Run vanilla haggle/bite
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(TraderScript), nameof(TraderScript.OnUse))]
        public static void PrefixOnUse(TraderScript __instance)
        {
            if (__instance.character == 4) // Dr. Alistair treats player wounds!
            {
                var state = __instance.GetComponent<CustomTraderState>();
                if (state == null)
                {
                    state = __instance.gameObject.AddComponent<CustomTraderState>();
                }

                if (!state.hasHealed)
                {
                    Body body = PlayerCamera.main.body;
                    if (body != null)
                    {
                        bool treated = false;
                        foreach (var limb in body.limbs)
                        {
                            if (limb != null && !limb.dismembered)
                            {
                                // Check if limb needs healing of any kind
                                if (limb.bleedAmount > 0.01f || limb.pain > 5f || limb.skinHealth < 99f || limb.muscleHealth < 99f || limb.infected || limb.shrapnel > 0)
                                {
                                    limb.bleedAmount = 0f;
                                    limb.pain = 0f;
                                    limb.skinHealth = 100f;
                                    limb.muscleHealth = 100f;
                                    limb.infected = false;
                                    limb.shrapnel = 0;
                                    treated = true;
                                }
                            }
                        }

                        if (body.bloodVolume < 99f)
                        {
                            body.bloodVolume = 100f;
                            treated = true;
                        }

                        if (treated)
                        {
                            state.hasHealed = true;
                            Sound.Play("combine", __instance.transform.position); // clinical bandaging/heal sound
                            __instance.talker.Talk("Lie still. Applying immediate field treatment... Bleeding stopped, limbs dressed, vitals stabilized.");
                            body.happiness += 5f;
                        }
                    }
                }
            }
            else if (__instance.character == 5) // Mama Cecile feeds the player!
            {
                var state = __instance.GetComponent<CustomTraderState>();
                if (state == null)
                {
                    state = __instance.gameObject.AddComponent<CustomTraderState>();
                }

                if (!state.hasFed)
                {
                    Body body = PlayerCamera.main.body;
                    if (body != null)
                    {
                        // Only feed the player if they are actually hungry (hunger < 95)
                        if (body.hunger < 95f)
                        {
                            state.hasFed = true;
                            body.hunger = Mathf.Min(100f, body.hunger + 40f); // feeds the player (increases satisfaction)
                            body.thirst = Mathf.Min(100f, body.thirst + 30f); // quenches thirst too (increases satisfaction)
                            body.happiness = Mathf.Min(100f, body.happiness + 12f);
                            Sound.Play("eatFlesh", __instance.transform.position); // eating sound
                            __instance.talker.Talk("Here you go, dear! Drink down this hot vegetable soup. There's plenty of nutrition in there.");
                        }
                    }
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TraderScript), nameof(TraderScript.MeetPlayer))]
        public static void PostfixMeetPlayer(TraderScript __instance)
        {
            // Empty to avoid double proximity triggers. 
            // All healing/feeding mechanics are now strictly handled upon trade menu interaction (OnUse).
        }
    }

    public class CustomTraderState : MonoBehaviour
    {
        public bool hasHealed = false;
        public bool hasFed = false;
    }
}
