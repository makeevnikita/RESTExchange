# REST API 
Криптобменник
## Доступные методы
Вид платёжной системы (банк, крипто, веб-кошелёк и т.д.)
|Метод|Параметры запроса|Описание|Результат|
|---|---|---|---|
|**GET** paymentmethod/get_all|Отсутствуют|Возвращает все способы оплаты|[<br>&nbsp;&nbsp;{<br>&nbsp;&nbsp;&nbsp;&nbsp;"Id":&nbsp;1,<br>&nbsp;&nbsp;&nbsp;&nbsp;"Name":&nbsp;"Банковкская карта"<br>&nbsp;&nbsp;},<br>&nbsp;&nbsp;{<br>&nbsp;&nbsp;&nbsp;&nbsp;"Id":&nbsp;2,<br>&nbsp;&nbsp;&nbsp;&nbsp;"Name":&nbsp;"Онлайн-кошелёк"<br>&nbsp;&nbsp;}<br>]|
|**GET** paymentmethod/get?id=1|id - id способа оплаты|Возвращает способ оплаты с id = 1|{<br>&nbsp;&nbsp;&nbsp;&nbsp;"Id":&nbsp;1,<br>&nbsp;&nbsp;&nbsp;&nbsp;"Name":&nbsp;"Банковкская карта"<br>}|
|**POST** paymentmethod/create?name=Банковская карта|name - название способа оплаты|Создаёт новый способ оплаты|Object was created successfully|
|**PUT** paymentmethod/update?id=3&newName=Банковская карта|id - id способа оплаты<br>newName - новое название|Изменяет способ оплаты|Object was updated successfully|
|**DELETE** paymentmethod/remove?id=3|id - id способа оплаты|Удаляет способ оплаты|Object was successfully deleted|

Валюта, которую отдаёт клиент (Bitcoin, LUNA, Сбербанк RUB, Альфабанк RUB, QIWI RUB и т.д.)
# Эти методы уже существуют, но я опишу их позже
|Метод|Параметры запроса|Описание|Результат|
|---|---|---|---|
|**GET** clientcurrency/get?id=1|id - id валюты|Возваращет валюту с id = 1||
