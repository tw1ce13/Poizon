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
    // Открытие корзины по клику на ссылку "Корзина"
    $(document).on("click", ".cart-link", function (event) {
        event.preventDefault(); // Предотвращаем переход по ссылке
        $.ajax({
            url: '/Order/ShowBasket', // URL для метода ShowBasket в OrderController
            type: "GET",
            success: function (data) {
                // При успешном получении данных, отображаем их в cart-overlay
                $(".cart-overlay").fadeIn();
                $(".cart-container").css("right", "0");
                $(".cart-container").html(data); // Заменяем содержимое контейнера полученными данными

                // Привязываем обработчики к кнопкам + и -
                $(".plus-btn").on("click", function () {
                    var input = $(this).siblings("input");
                    var currentValue = parseInt(input.val());
                    input.val(currentValue + 1);
                });

                $(".minus-btn").on("click", function () {
                    var input = $(this).siblings("input");
                    var currentValue = parseInt(input.val());
                    if (currentValue > 1) {
                        input.val(currentValue - 1);
                    }
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
});
