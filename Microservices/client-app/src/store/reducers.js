
import { combineReducers } from 'redux';
import products from './modules/products';
import customers from './modules/customers';  
import orders    from './modules/orders';     

export default combineReducers({
  products,
  customers,
  orders,
});
