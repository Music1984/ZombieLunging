using System;
using Exiled.Events.EventArgs;
using Object = UnityEngine.Object;

namespace ZombieLunging
{
	public class EventHandlers
	{
		public Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		public void OnSetClass(ChangingRoleEventArgs ev)
		{
			if (ev.Player.Nickname == "Dedicated Server") return;

			PlayerSpeeds component1 = ev.Player.ReferenceHub.gameObject.GetComponent<PlayerSpeeds>();
			if ((Object)component1 != (Object)null) component1.Destroy();
			ev.Player.ReferenceHub.gameObject.AddComponent<PlayerSpeeds>();

			CustomZombie component = ev.Player.ReferenceHub.gameObject.GetComponent<CustomZombie>();
			if (ev.NewRole != RoleType.Scp0492) return;
			if ((Object)component != (Object)null) component.Destroy();
			ev.Player.ReferenceHub.gameObject.AddComponent<CustomZombie>();
		}
	}
}