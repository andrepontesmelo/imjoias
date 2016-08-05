SENHA=''
PWD="--password=$SENHA"
DB="--database=imjoias"
mysql -u root $PWD $DB -e "select count(*) from mercadoria" >> t1.out
mysql -u root $PWD $DB -e "select * from mercadoria" >> t2.out
mysql -u root $PWD $DB -e  "select * from tabelamercadoria" >> t3.out
mysql -u root $PWD $DB -e  "select count(*) from mercadoria where foradelinha=0" >> t4.out
