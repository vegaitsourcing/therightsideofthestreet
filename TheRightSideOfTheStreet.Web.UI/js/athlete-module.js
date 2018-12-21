'use strict';

module.exports = {

	filterAthletes: function () {
		// filter athletes on ENTER press
		$("#sw-atlete-search").on("keypress", function (e) {
			if (e.keyCode === 13) {
				Submit();
			}
		});

		// filter athletes on button click
		$("[filter-atlete]").click(function () {
			Submit();
		});

		function Submit() {

			$('[athlete-module]').slick('slickUnfilter');
			const name = $('#sw-atlete-search').val();

			if ($("[athlete-module]:contains('" + name + "')").length === 0) return;

			if (!name || name === "") {
				$('[athlete-module]').slick('slickUnfilter');
			}

			$('[athlete-module]').slick('slickFilter', ':contains("' + name + '")');
			$('#sw-atlete-search').val('');

		}

		// 'contains' function is case insensitive now
		jQuery.expr[':'].contains = function (a, i, m) {
			return jQuery(a).text().toUpperCase().indexOf(m[3].toUpperCase()) >= 0;
		};	
	},

	loadMore: function () {

		var numberOfShown = 0;
		let $loadbutton = $('#loadAthletes');
		let numberOfItems = $loadbutton.data("number");
		$('.sw-atlete-item[data-item]').hide();
		showGroups(numberOfShown);
		hideLoadMoreButton(numberOfItems, numberOfShown);

		$loadbutton.on('click', function () {
			if (numberOfShown * 6 < numberOfItems) {
				numberOfShown = numberOfShown + 1;
				showGroups(numberOfShown);
				hideLoadMoreButton(numberOfItems, numberOfShown);
			}
		});

		function hideLoadMoreButton(numberOfItems, numberOfShown) {
			if (numberOfItems === undefined || numberOfItems < 6 || (numberOfShown + 1) * 6 >= numberOfItems) {
				
				$loadbutton.hide();
			}
		}
		function showGroups(numb) {
			for (var i = numb * 6; i < numb * 6 + 6; i++) {
				$('.sw-atlete-item[data-numbr=' + i + ']').show();
			}
		}
	}
};