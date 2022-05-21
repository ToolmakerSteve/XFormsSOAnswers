using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Timer = System.Timers.Timer;

namespace XFSOAnswers
{
    public partial class MainPage : ContentPage
    {
        // REPLACE "XFSOAnswers" with your project's assembly name.
        public const string AssemblyName = "XFSOAnswers";


        public enum Orientation
        {
            One, Two, Three, Four
        }

        const int NOrientations = 4;


        public MainPage()
        {
            // Assuming stored locally in files or resources.
            // If need server queries, recommend not doing this in constructor.
            LoadOurImages();

            InitializeComponent();
            // In this simple example, the binding sources are in the page itself.
            BindingContext = this;

            Test();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            BackgroundTestLoop();
        }


        private void Test()
        {
            //Device.StartTimer(...);
            //var xc = Constraint.Constant(160);
            //Test_Prisoners();

            //FileResult fileResult = new FileResult("path");
            //Task<System.IO.Stream> streamTask = fileResult.OpenReadAsync();
            //Func<System.IO.Stream> streamFunc = () => fileResult.OpenReadAsync().Result;

            //// ----- Remove Frame -----
            //var topView = this.Content as ContentView;
            //var layout = (Layout<View>)topView.Children[0];
            //this.Content = layout;


            //SetImageFromPhoto();

            //var json = "{ 0: { \"url\": \"\", \"name\": \"\"} }"; var obj = JObject.Parse(json);
        }

        public ImageSource PickerSource
        {
            get => _pickerSource;
            set
            {
                _pickerSource = value;
                OnPropertyChanged();
            }
        }
        private ImageSource _pickerSource;

        private void SetImageFromPhoto()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Please pick a photo" });
                if (result != null)
                {
                    ////var stream = await result.OpenReadAsync();
                    ////PickerSource = ImageSource.FromStream(() => stream);
                    PickerSource = ImageSource.FromFile(result.FullPath);
                }
            });
        }

        const int S10 = 10;
        const int S5 = 5;
        const int S1 = 1;
        const int S0 = 0;
        private void Test_Prisoners()
        {

            Prisoner[] allPrisoners = { new Prisoner("A", true), new Prisoner("B", false) };
            DetermineSentences(allPrisoners);
        }

        private void DetermineSentences(Prisoner[] allPrisoners)
        {
            Tuple<int, int>[][] outcomes = {
                new Tuple<int,int>[]{ AsTuple(S1, S1), AsTuple(S0, S10) },
                new Tuple<int,int>[]{ AsTuple(S0, S10), AsTuple(S5, S5) }
            };
            if (allPrisoners.Length != 2)
                throw new InvalidProgramException("Must be 2 prisoners");

            var sentences = outcomes[AsIndex(allPrisoners[0].Cooperate)][AsIndex(allPrisoners[1].Cooperate)];
            allPrisoners[0].Sentence = sentences.Item1;
            allPrisoners[1].Sentence = sentences.Item2;
        }
        private static int AsIndex(bool cooperate)
        {
            return cooperate ? 1 : 0;
        }
        private static Tuple<T, T> AsTuple<T>(T a, T b)
        {
            return new Tuple<T, T>(a, b);
        }

        private void DetermineSentencesA(Prisoner[] allPrisoners)
        {
            var cooperates = allPrisoners.Where(p => p.Cooperate).ToList();
            var nonCooperates = allPrisoners.Where(p => !p.Cooperate).ToList();
            if (cooperates.Count == 0)
            {
                GiveSentence(nonCooperates, S1);
            }
            else if (cooperates.Count == allPrisoners.Length)
            {
                GiveSentence(cooperates, S5);
            }
            else
            {
                // Some but not all prisoners cooperate.
                GiveSentence(cooperates, S0);
                GiveSentence(nonCooperates, S10);
            }
        }

        private void GiveSentence(IEnumerable<Prisoner> prisoners, int amount)
        {
            foreach (var prisoner in prisoners)
            {
                prisoner.Sentence = amount;
            }
        }

        class Prisoner
        {
            public string Name;
            public bool Cooperate;
            public int Sentence;

            public Prisoner(string name, bool cooperate)
            {
                Name = name;
                Cooperate = cooperate;
            }
        }

        Constraint XC => Constraint.Constant(X);

        static Random Rand = new Random();

        private void BackgroundTestLoop()
        {
            Task.Run(async () =>
            {
                const int NTimes = 20;
                for (int i = 0; i < NTimes; i++)
                {
                    await Task.Delay(3000);

                    Orientation nextOrient = (Orientation)Rand.Next(NOrientations);
                    // Only affect UI from main thread.
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Orient = nextOrient;
                    });
                }
            });
        }

        public Orientation Orient
        {
            get => _orient;
            set
            {
                _orient = value;
                // When Orient changes, that affects the values of these properties.
                OnPropertyChanged(nameof(Source1A));
                OnPropertyChanged(nameof(Source1B));
                OnPropertyChanged(nameof(Source2A));
                OnPropertyChanged(nameof(Source2B));
            }
        }
        private Orientation _orient = Orientation.One;

        public ImageSource Source1A => Sources[Indexes1A[(int)Orient]];
        public ImageSource Source1B => Sources[Indexes1B[(int)Orient]];
        public ImageSource Source2A => Sources[Indexes2A[(int)Orient]];
        public ImageSource Source2B => Sources[Indexes2B[(int)Orient]];


        List<string> ResourcePaths = new List<string> {
            "apple_x64.png", "boat_on_water_x64.png", "pine_tree_x64.png", "unicorn_head_pink_x64.png"};

        List<ImageSource> Sources = new List<ImageSource>();

        // Change these as needed.
        List<int> Indexes1A = new List<int> { 0, 1, 2, 3 };
        List<int> Indexes1B = new List<int> { 1, 2, 3, 0 };
        List<int> Indexes2A = new List<int> { 2, 3, 0, 1 };
        List<int> Indexes2B = new List<int> { 3, 0, 1, 2 };



        private void LoadOurImages()
        {
            foreach (var path in ResourcePaths)
                Sources.Add(CreateOurSource(path));
        }

        private ImageSource CreateOurSource(string resourcePath)
        {
            // For embedded resources stored in project folder "Media".
            var resourceID = $"{AssemblyName}.Media.{resourcePath}";
            // Our media is in the cross-platform assembly. Same is this page.
            Assembly assembly = this.GetType().GetTypeInfo().Assembly;
            ImageSource source = ImageSource.FromResource(resourceID, assembly);
            return source;
        }

        #region --- Timers ---
        // --- Fixed-delay timer vs. Delay-after-finish-work timer ---
        Timer _timer;

        // HACK: Maintain duplicate list of our handlers, in order to remove them.
        private List<System.Timers.ElapsedEventHandler> _ourElapsedHandlers = new List<System.Timers.ElapsedEventHandler>();
        //private event System.Timers.ElapsedEventHandler _ourTimerElapsedCopy;
        public void AddTimerElapsedHandler(System.Timers.ElapsedEventHandler handler)
        {
            _timer.Elapsed += handler;
            // ALTERNATIVE ways to keep track.
            _ourElapsedHandlers.Add(handler);
            //_ourTimerElapsedCopy += handler;
        }
        public void ClearTimerElapsed()
        {
            //Delegate[] handlers = _ourTimerElapsedCopy.GetInvocationList();
            //foreach (Delegate handler in handlers)
            //    _timer.Elapsed -= (System.Timers.ElapsedEventHandler)handler;
            //_ourTimerElapsedCopy = null;

            foreach (var handler in _ourElapsedHandlers)
                _timer.Elapsed -= handler;
            _ourElapsedHandlers.Clear();
        }

        private void StartFixedDelayTimer(float seconds, Action action)
        {
            _timer = new Timer(1000 * seconds);
            // Repeat the timer event until explicitly stopped. (true by default).
            _timer.AutoReset = true;

            //_timer.Elapsed += (sender, e) => action();
            System.Timers.ElapsedEventHandler handler = (sender, e) => action();
            AddTimerElapsedHandler(handler);

            _timer.Start();
        }

        //private delegate void ElapsedDeleg(object sender, System.Timers.ElapsedEventArgs e);

        // Fixed-delay timer vs. Delay-after-finish-work.
        // For long running "action", increase "idleSeconds" to guarantee more time for other background tasks.
        private void StartFixedDelayTimerAvoidReentrancy(float seconds, Action action, float idleSeconds = 0.1f)
        {
            // In case a very short "seconds" is given, without a correspondingly short "idleSeconds".
            // Comment out, if you want to allow idleSeconds to force multiple time events to be skipped.
            idleSeconds = Math.Min(idleSeconds, 0.5f * seconds);

            _timer = new Timer(1000 * seconds);
            // Repeat the timer event until explicitly stopped. (true by default).
            _timer.AutoReset = true;

            bool entered = false;
            _timer.Elapsed += (sender, e) =>
            {
                if (entered)
                    // Timer code already running! Skip this one.
                    return;
                entered = true;
                try
                {
                    action();
                    // IMPORTANT: This is needed to "see and skip" next timer event,
                    // if it happens during "action". Without this, timer events can "pile up",
                    // starving other background tasks.
                    System.Threading.Thread.Sleep((int)(1000 * idleSeconds));
                }
                finally
                {
                    entered = false;
                }
            };

            _timer.Start();
        }

        private void StartDelayBetweenWorkTimer(float seconds, Action action)
        {
            _timer = new Timer(1000 * seconds);
            // Only fire the timer once. (But in Elapsed, we fire it again.)
            _timer.AutoReset = false;
            _timer.Elapsed += (sender, e) =>
            {
                action();
                // Fire the timer again.
                _timer.Start();
            };
            _timer.Start();
        }
        #endregion
    }
}
