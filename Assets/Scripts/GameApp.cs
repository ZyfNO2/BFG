
public class  GameApp:Singleton<GameApp>
{

    public static SoundManager SoundManager;

    public static ControllerManager ControllerManager;

    public static ViewManager ViewManager;

    public static ConfigManager ConfigManager;

    public static CameraManager CameraManager;

    public static MessageCenter MessageCenter;

    public static TimerManager TimerManager;

    public static FightWorldManager FightWorldManager;

    public static MapManager MapManager;

    public static GameDataManager GameDataManager;

    public static UserInputManager UserInputManager;

    public static CommandManager CommandManager;

    public static SkillManager SkillManager;
    
    public override void Init()
    {
        CommandManager = new CommandManager();
        
        UserInputManager = new UserInputManager();

        FightWorldManager = new FightWorldManager();
        
        TimerManager = new TimerManager();
        
        SoundManager = new SoundManager();

        ControllerManager = new ControllerManager();

        ViewManager = new ViewManager();

        ConfigManager = new ConfigManager();

        CameraManager = new CameraManager();
        
        MessageCenter = new MessageCenter();

        MapManager = new MapManager();

        GameDataManager = new GameDataManager();

        SkillManager = new SkillManager();


    }

    public override void Update(float dt)
    {
        UserInputManager.Update();
        TimerManager.OnUpdate(dt);
        FightWorldManager.Update(dt);
        CommandManager.Update(dt);
        SkillManager.Update(dt);
    }
}
