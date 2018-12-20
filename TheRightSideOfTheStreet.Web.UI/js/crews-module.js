'use strict';

module.exports = {

	chooseCrew: function () {

		$(".sw-crews-city-item").on("click", function () {
			const $this = $(this);
			const itemKey = $this.data("city-key");
			const $item = $("div.sw-crews-crew-item[data-city-key=" + itemKey + "]");

			if (!$item) return;

			$item.siblings("div.sw-crews-crew-item[data-city-key]").hide();
			$item.show();
		});

		$(".sw-crews-crew-item").on("click", function () {
			const $this = $(this);
			const itemKey = $this.data("crew-key");
			const $item = $("div.wrap[data-crew-key=" + itemKey + "]");

			if (!$item) return;
			$item.siblings("div.wrap[data-crew-key]").hide();
			$item.show();
		});

		$("[back-to-wrap]").on("click", function () {
			$("div.sw-crews-crew-item[data-city-key]").hide();
		});
	}

};