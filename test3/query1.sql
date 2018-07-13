select cln.client_name
from Clients cln inner join Orders ord on cln.client_id = ord.client_id
where ord.order_sum > 50