UPDATE titles
SET ytd_sales = titles.ytd_sales + sales.qty
FROM titles, sales
     WHERE titles.title_id = sales.title_id
           AND sales.ord_date = (SELECT MAX(sales.ord_date) FROM sales


UPDATE NajavaKola
SET Realizovano = '1'
FROM NajavaKola, SlogKola
     WHERE NajavaKola.IBK = SlogKola.IBK
           AND sales.ord_date = (SELECT MAX(sales.ord_date) FROM sales