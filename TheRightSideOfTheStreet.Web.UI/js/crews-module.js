'use strict';

module.exports = {

	chooseCrew: function () {

		$(".sw-crews-city-item").on("click", function () {
			$('#loadbuttonCrew').show();
			const $this = $(this);
			const itemKey = $this.data("city-key");
			const $item = $("div[crewByCity][data-city-key=" + itemKey + "]");
			var NumberOfCrews = $item.children().length;
			if (!$item) return;

			$item.siblings("div[crewByCity][data-city-key]").hide();
			$("div.sw-crews-crew-item[data-it]").hide();
			$item.show();
			$item.children().show();
			myFunc(NumberOfCrews, itemKey);

		});

		$(".sw-crews-crew-item").on("click", function () {
			const $this = $(this);
			const itemKey = $this.data("crew-key");
			const $item = $("div.wrap[data-crew-key=" + itemKey + "]");

			if (!$item) return;
			$item.siblings("div.wrap[data-crew-key]").hide();
			$item.show();
		});

		$("[back-to-cities]").on("click", function () {
			$("div[data-city-key]").hide();
			$("div.sw-crews-list-wrap").show();
			$("div.sw-crews-list-wrap").children().show();

			//// call again
			$('#loadbutton').show();

			var numberOfShown = 0;
			let $loadbutton = $('#loadbutton');
			let numberOfItems = $loadbutton.data("number");
			$('.sw-crews-city-item[data-item]').hide();

			showGroups(numberOfShown);
			hideLoadMoreButton(numberOfItems, numberOfShown);

			$loadbutton.on('click', function () {
				if (numberOfShown * 12 < numberOfItems) {
					numberOfShown = numberOfShown + 1;
					showGroups(numberOfShown);
					hideLoadMoreButton(numberOfItems, numberOfShown);
				}
			});

			function hideLoadMoreButton(numberOfItems, numberOfShown) {
				if (numberOfItems === undefined || numberOfItems < 12 || (numberOfShown + 1) * 12 >= numberOfItems) {
					$loadbutton.hide();
				}
			}
			function showGroups(numb) {
				for (var i = numb * 12; i < numb * 12 + 12; i++) {
					$('.sw-crews-city-item[data-numbr=' + i + ']').show();
				}
			}


		});


		function myFunc(num, cityKey) {
			$(".sw-crews-crew-item").hide();
			var numberOfShown = 0;
			let $loadbuttonCrew = $('#loadbuttonCrew');
			let numberOfItems = num;

			showGroups(numberOfShown);
			hideLoadMoreButtonCrew(numberOfItems, numberOfShown);

			$loadbuttonCrew.on('click', function () {

				if (numberOfShown * 6 < numberOfItems) {
					numberOfShown = numberOfShown + 1;
					showGroups(numberOfShown);
					hideLoadMoreButtonCrew(numberOfItems, numberOfShown);
				}
			});

			function hideLoadMoreButtonCrew(numberOfItems, numberOfShown) {
				if (numberOfItems === undefined || numberOfItems < 6 || (numberOfShown + 1) * 6 >= numberOfItems) {
					$loadbuttonCrew.hide();
				}
			}
			function showGroups(numb) {

				for (var i = numb * 6; i < numb * 6 + 6; i++) {
					$("div[crewByCity][data-city-key='" + cityKey + "']").children("[data-num='" + i + "']").show();
				}
			}

		}
	},

	loadMoreCities: function () {

		var numberOfShown = 0;
		let $loadbutton = $('#loadbutton');
		let numberOfItems = $loadbutton.data("number");
		$('.sw-crews-city-item[data-item]').hide();

		showGroups(numberOfShown);
		hideLoadMoreButton(numberOfItems, numberOfShown);

		$loadbutton.on('click', function () {
			if (numberOfShown * 12 < numberOfItems) {
				numberOfShown = numberOfShown + 1;
				showGroups(numberOfShown);
				hideLoadMoreButton(numberOfItems, numberOfShown);
			}
		});

		function hideLoadMoreButton(numberOfItems, numberOfShown) {
			if (numberOfItems === undefined || numberOfItems < 12 || (numberOfShown + 1) * 12 >= numberOfItems) {
				$loadbutton.hide();
			}
		}
		function showGroups(numb) {
			for (var i = numb * 12; i < numb * 12 + 12; i++) {
				$('.sw-crews-city-item[data-numbr=' + i + ']').show();
			}
		}
	}


};