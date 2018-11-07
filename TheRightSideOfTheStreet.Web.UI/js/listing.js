'use strict';

module.exports = {

	donators: function () {
		const $donatorsWrapper = $('.our-donators .wrap');
		if (!$donatorsWrapper) return;

		const pageKey = $donatorsWrapper.data('page-key');
		const controllerUrl = $donatorsWrapper.data('controller-url');

		$donatorsWrapper.on('click', '.pagination a', function () {
			const $this = $(this);
			const page = $this.data('page');
			$.get(controllerUrl, { pageKey: pageKey, page: page }, function (response) {
				$donatorsWrapper.children('.donators-content').remove();
				$donatorsWrapper.append(response);
			}, 'html');

		});
	}
};