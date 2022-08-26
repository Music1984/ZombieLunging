using System;
using CommandSystem;
using Exiled.API.Features;

namespace ZombieLunging.Commands
    {
        [CommandHandler(typeof(ClientCommandHandler))]
        class Lunge : ICommand
        {
             public string Command { get; } = "lunge";
             public string[] Aliases { get; } = { };
             public string Description { get; } = "Lunge Command";
             public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
             Player player = Player.Get(sender);
             if (player.Role.Type != RoleType.Scp0492)
             {
                 response = "You are not a zombie!";
                 return false;
             }
             
             if (player.ReferenceHub.GetComponent<CustomZombie>().cooldown > 0)
             {
                 if (!string.IsNullOrEmpty(Plugin.instance.Config.LungeMessage)) player.Broadcast(2, Plugin.instance.Config.LungeCooldownMessage.Replace("{time}",  Math.Round(player.ReferenceHub.GetComponent<CustomZombie>().cooldown).ToString()));
             }
             else if (!player.ReferenceHub.GetComponent<CustomZombie>().lunging)
             {
                 if (!string.IsNullOrEmpty(Plugin.instance.Config.LungeMessage)) player.Broadcast(5, Plugin.instance.Config.LungeMessage);
                 player.ReferenceHub.GetComponent<CustomZombie>().ActivateSpeedUp();
                 player.ShowHint("<i>Lunging!</i>");
                 response = "You have activated your lunge!";
                 return true;

             }
             else
             {
                 player.ShowHint("<i><color=red>You are already lunging!</color></i>");
                 response = "You are already lunging!";
                 return false;
             }
              response = "Error has occured";
              return false;
            }
        }
    }
    