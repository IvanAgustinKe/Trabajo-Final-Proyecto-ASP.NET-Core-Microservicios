import { call, put, takeLatest } from 'redux-saga/effects';
import * as api from '../../api/products';


const FETCH_PRODUCTS    = 'products/FETCH';
const FETCH_PRODUCTS_OK = 'products/FETCH_OK';
const FETCH_PRODUCTS_ER = 'products/FETCH_ER';


export const fetchProducts = () => ({ type: FETCH_PRODUCTS });


const initialState = { list:[], loading:false, error:null };
export default function reducer(state = initialState, action) {
  switch(action.type) {
    case FETCH_PRODUCTS: return { ...state, loading:true };
    case FETCH_PRODUCTS_OK:
      return { ...state, loading:false, list:action.payload };
    case FETCH_PRODUCTS_ER:
      return { ...state, loading:false, error:action.error };
    default: return state;
  }
}


function* loadProducts() {
  try {
    const data = yield call(api.getAllProducts);
    yield put({ type: FETCH_PRODUCTS_OK, payload: data });
  } catch(err) {
    yield put({ type: FETCH_PRODUCTS_ER, error: err.message });
  }
}

export function* watchProducts() {
  yield takeLatest(FETCH_PRODUCTS, loadProducts);
}
