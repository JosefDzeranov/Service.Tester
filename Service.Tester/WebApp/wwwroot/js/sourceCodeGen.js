$(() => {
    const $output = $('.source-code-output');
    const $input = $('.source-code-input');

    $output.delegate('.source-code-output__item', 'click', onItemClick);

    $input.change(onSourceCodeChange);

    function onSourceCodeChange(e) {
        const value = e.target.value;

        if (!value) return;

        $output.empty();

        $output.append(value.split('\n').map((text, index) => {
            text = text.replace(/\s/g, '&nbsp;');

            return $('<div/>',
                {
                    'class': 'source-code-output__item',
                    html: `${index + 1}&nbsp;${text}`,
                    'data-id': index + 1
                });
        }));
    }

    function onItemClick() {
        const $item = $(this);

        $('.source-code-output__item-active').removeClass('source-code-output__item-active');
        $item.addClass('source-code-output__item-active');
        $('.breakpoint-line').val($item.data('id'));
    }
});