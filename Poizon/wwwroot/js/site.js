$(document).ready(function () {
    // Открытие формы регистрации
    $(".login-button").on("click", function () {
        $(".registration-overlay").fadeIn();
        $(".registration-form-container").css("right", "0");
    });

    // Закрытие формы регистрации
    $(".close-button").on("click", function () {
        $(".registration-overlay").fadeOut();
        $(".registration-form-container").css("right", "-400px");
    });
});
    // Открытие корзины
$(document).ready(function () {
    // Открытие корзины
    $(document).on("click", ".cart-link", function (event) {
        event.preventDefault(); // Предотвращаем переход по ссылке
        $.ajax({
            url: '/Order/ShowBasket', // URL для метода ShowBasket в OrderController
            type: "GET",
            success: function (data) {
                // При успешном получении данных, отображаем их в cart-overlay
                $(".cart-overlay").fadeIn();
                $(".cart-container").css("right", "0");
                $(".cart-container").html(data);
                updateTotal(); // Заменяем содержимое контейнера полученными данными

                // Удаляем старые обработчики событий
                $(".plus-btn").off("click");
                $(".minus-btn").off("click");
                $(".custom-input").off("change");

                // Привязываем обработчики к кнопкам + и -
                $(".plus-btn").on("click", function () {
                    var itemId = $(this).data("id");
                    var input = $("input[data-id='" + itemId + "']");
                    var currentValue = parseInt(input.val());
                    input.val(currentValue + 1);
                    updateItemTotal(input); // Вызываем updateItemTotal(), чтобы обновить стоимость товара
                });

                $(".minus-btn").on("click", function () {
                    var itemId = $(this).data("id");
                    var input = $("input[data-id='" + itemId + "']");
                    var currentValue = parseInt(input.val());
                    if (currentValue > 1) {
                        input.val(currentValue - 1);
                        updateItemTotal(input); // Вызываем updateItemTotal(), чтобы обновить стоимость товара
                    }
                });

                $(".checkout-button").on("click", function () {
                    // Получаем общую стоимость из элемента с классом "total-price"
                    var total = parseInt($(".total").text().replace("Итого: ", "").replace(" ₽", ""));

                    // Перенаправляем пользователя на страницу с формой и передаем общую стоимость как параметр в URL
                    window.location.href = '/Order/MakeOrder?total=' + total;
                });

                $(".custom-input").on("change", function () {
                    var itemId = $(this).data("id");
                    var currentValue = parseInt($(this).val());
                    if (isNaN(currentValue) || currentValue < 1) {
                        $(this).val(1);
                    }
                    updateItemTotal($(this)); // Вызываем updateItemTotal(), чтобы обновить стоимость товара
                });

                // Привязываем обработчик к кнопке закрытия
                $(".close-button").on("click", function () {
                    $(".cart-overlay").fadeOut();
                });
            },
            error: function () {
                // Обработка ошибки, если не удалось получить данные
                alert("Ошибка при загрузке корзины.");
            }
        });
    });


    $(document).on("click", ".cart-item-remove-btn", function (event) {
        event.preventDefault(); // Предотвращаем переход по ссылке

        var itemId = $(this).data("id");
        var cartItem = $(this).closest(".cart-item"); // Запоминаем элемент, который будет удален

        $.ajax({
            url: '/Order/RemoveFromBasket', // URL для метода RemoveFromBasket в OrderController
            type: "POST",
            data: { id: itemId }, // Передаем идентификатор товара в параметре 'id'
            success: function (data) {
                // Если успешно удален из корзины на сервере, обновляем корзину на клиенте
                cartItem.remove(); // Удаляем элемент из DOM
                updateTotal(); // Обновляем общую стоимость после удаления товара
            },
            error: function () {
                // Обработка ошибки, если не удалось удалить из корзины
                alert("Ошибка при удалении товара из корзины.");
            }
        });
    });

    // Функция для обновления стоимости одного товара после изменения количества
    function updateItemTotal(input) {
        var price = parseFloat(input.data("price")); // Используем атрибут data-price для получения цены товара
        var quantity = parseInt(input.val());
        var itemTotal = price * quantity;
        input.parents(".cart-item").find(".cart-item-total").text("Стоимость: " + itemTotal + " ₽");
        updateTotal(); // Вызываем updateTotal(), чтобы обновить общую стоимость
    }

    // Функция для обновления общей стоимости корзины
    function updateTotal() {
        var total = 0;
        $(".cart-item").each(function () {
            var price = parseFloat($(this).find(".custom-input").data("price")); // Используйте data-price атрибут для получения цены
            var quantity = parseInt($(this).find(".custom-input").val());

            if (!isNaN(price) && !isNaN(quantity)) { // Проверка на NaN
                var itemTotal = price * quantity;
                total += itemTotal;
            }
        });
        $(".total").text("Итого: " + total + " ₽");
    }
});
