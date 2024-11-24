using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;

namespace RoundEndKill;

public class RoundEndKill : BasePlugin
{
    public override string ModuleName => "RoundEndKill";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "Josoa";
    public override string ModuleDescription => "A simple plugin that kill everyone when round end";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventRoundEnd>(OnRoundEnd);
    }

    private HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info)
    {   
        var players = Utilities.GetPlayers();
        
        AddTimer(2.0f, () => {
            foreach (var player in players)
            {
                player.CommitSuicide(false, true);
            }
        });

        return HookResult.Continue;
    }
}