'use strict';

module.exports = {

	filterAthletes: function () {

		jQuery.expr[':'].contains = function (a, i, m) {
			return jQuery(a).text().toUpperCase().indexOf(m[3].toUpperCase()) >= 0;
		};
		
		$("[filter-atlete]").on("click", function () {

			const name = $('#sw-atlete-search').val();
			var index = $("div.slick-slide:contains('" + name + "')").data("slick-index");
			
			$('.sw-atlete-slider').slick('slickGoTo', index);
		});
	}
};