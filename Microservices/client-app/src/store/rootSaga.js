
import { all } from 'redux-saga/effects';
import { watchProducts }  from './modules/products';
import { watchCustomers } from './modules/customers'; 
import { watchOrders }    from './modules/orders';    

export default function* rootSaga() {
  yield all([
    watchProducts(),
    watchCustomers(),
    watchOrders(),
  ]);
}
