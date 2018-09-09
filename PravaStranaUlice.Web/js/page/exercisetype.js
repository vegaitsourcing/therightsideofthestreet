'use strict';

let functions = require('../functions'); //.. Znci 2 foldera dalje

let showItems = {
	init: function () {
		getPressReleases($('button.active').attr('id')); //dole def.fja koja u startu hvata koja je str aktivna I ispisuje odgovarajuce elemente

		$("button.tab-link").on("click", function () {
			let filter = this.id;
			getPressReleases(filter);
		}); //uzima ID buttona na koji smo kliknuli

		function getPressReleases(filter) {
			let $pressReleasesContainer = $("#js-press-releases-container");
			getPressReleasesByPage(1, filter);

			function getPressReleasesByPage(page, filter) {
				let data = {
					currentPage: $pressReleasesContainer.data("page"), //hvata vrednost def.  Pod atributom data-page=" " 
					year: filter,
					page: page
				}
				$.get($pressReleasesContainer.data("url-controller"), data, function (response) {
					$pressReleasesContainer.html(response); //u ovom elementu se ispisuje html dobijen iz response
					functions.pagination(getPressReleasesByPage);
				});
			}
		}
	}

};

module.exports = showItems;

