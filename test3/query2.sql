select cln.client_name, sum(ord.order_sum) as summa
from Clients cln inner join Orders ord on cln.client_id = ord.client_id
group by cln.client_name
having sum(ord.order_sum) > 100 