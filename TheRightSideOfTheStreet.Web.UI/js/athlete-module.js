'use strict';

module.exports = {

	filterAthletes: function () {
		// filter athlete on ENTER press
		$("#sw-atlete-search").on("keypress", function (e) {
			if (e.keyCode === 13) {
				Submit();
			}
		});

		// filter athlete on button click
		$("[filter-atlete]").click(Submit);
		
		function Submit() {
			const name = $('#sw-atlete-search').val();
			var index = $("div.slick-slide:contains('" + name + "')").data("slick-index");

			$('.sw-atlete-slider').slick('slickGoTo', index);
			$('#sw-atlete-search').val('');
		}

		// 'contains' function is case insensitive now
		jQuery.expr[':'].contains = function (a, i, m) {
			return jQuery(a).text().toUpperCase().indexOf(m[3].toUpperCase()) >= 0;
		};
	}
};