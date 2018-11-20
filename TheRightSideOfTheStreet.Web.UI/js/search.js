'use strict';

module.exports = {

	search: function () {

		$(".submit-btn").on('click', function (e) {
			e.preventDefault();

			const searchInput = $("[query-item]").val();
			const $form = $(this).closest('form');

			if (!searchInput || !searchInput.trim()) return;
			if (!$form.valid()) return;

			$form.submit();

		});

	
	}
};