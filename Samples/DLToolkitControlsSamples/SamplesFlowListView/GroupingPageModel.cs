﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamvvm;
using System.Collections.Generic;
using System.Threading.Tasks;
using DLToolkit.Forms.Controls;
using DLToolkitControlsSamples.SamplesFlowListView;

namespace DLToolkitControlsSamples
{
    public class GroupingPageModel : InfiniteLoadingPageModel
	{
		public GroupingPageModel()
		{
			ScrollToCommand = new BaseCommand((arg) =>
			{
				var page = this.GetCurrentPage() as GroupingPage;
				var items = Items.SelectMany(v => (IEnumerable<object>)v).ToList();
				page.FlowScrollTo(items[items.Count / 2]);
			});
		}

		public new void ReloadData()
		{
			var exampleData = new List<SimpleItem>();

			var random = new Random(DateTime.Now.Millisecond);
			var howMany = 60;
			TotalRecords = 120;

			for (int i = 0; i < howMany; i++)
			{
				exampleData.Add(new SimpleItem() { Title = Guid.NewGuid().ToString("N").Substring(0, 8) });
			}

			var sorted = exampleData
				.OrderBy(item => item.Title)
				.GroupBy(item => item.Title[0].ToString())
				.Select(itemGroup => new Grouping<string, SimpleItem>(itemGroup.Key, itemGroup, random.Next(1, 6)))
				.ToList();

			sorted.Insert(0, new Grouping<string, SimpleItem>("-"));

			Items = new FlowObservableCollection<object>(sorted);
		}

		protected override async Task LoadMoreAsync()
		{
			var oldTotal = Items.Count;

			await Task.Delay(3000);

			var howMany = 60;

			var groups = (Items.Last() as Grouping<string, SimpleItem>);

			groups.BatchStart();

			for (int i = oldTotal; i < oldTotal + howMany; i++)
			{
				groups.Add(new SimpleItem() { Title = Guid.NewGuid().ToString("N").Substring(0, 8) });
			}

			groups.BatchEnd();

			IsLoadingInfinite = false;
		}

        public ICommand ScrollToCommand { get; set; }
	}
}
