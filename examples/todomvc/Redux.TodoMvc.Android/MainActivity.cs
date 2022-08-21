﻿using Android.App;
using Android.OS;
using Redux.TodoMvc.States;
using System.Collections.Immutable;

namespace Redux.TodoMvc.Android
{
    [Activity(Label = "Redux.TodoMvc.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static IStore<ApplicationState> Store { get; private set; }

        public MainActivity()
        {
            var initialState = new ApplicationState
            {
                Todos = ImmutableArray<Todo>.Empty,
                Filter = TodosFilter.All
            };

            Store = new Store<ApplicationState>(initialState, Reducers.ReduceApplication);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
        }
    }
}

