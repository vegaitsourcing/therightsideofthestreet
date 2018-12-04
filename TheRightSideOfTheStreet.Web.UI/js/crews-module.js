'use strict';

module.exports = {

	chooseCrew: function () {

		$(".sw-crews-city-item").on("click", function () {
			const $this = $(this);
			const itemKey = $this.data("city-key");
			const $item = $("div.sw-crews-crew-item[data-city-key=" + itemKey + "]");

			if (!$item) return;
			$item.siblings("div.sw-crews-crew-item[data-city-key]").attr('style', 'display: none !important');
			$item.show();
		});
	}
};