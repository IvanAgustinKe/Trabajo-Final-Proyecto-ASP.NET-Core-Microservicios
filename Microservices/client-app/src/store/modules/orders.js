
import { call, put, takeLatest } from 'redux-saga/effects';
import * as api from '../../api/orders';


const FETCH_ORDERS      = 'orders/FETCH';
const FETCH_ORDERS_OK   = 'orders/FETCH_OK';
const FETCH_ORDERS_ERR  = 'orders/FETCH_ERR';

const CREATE_ORDER      = 'orders/CREATE';
const CREATE_ORDER_OK   = 'orders/CREATE_OK';
const CREATE_ORDER_ERR  = 'orders/CREATE_ERR';


export const fetchOrders  = () => ({ type: FETCH_ORDERS });
export const createOrder  = dto => ({ type: CREATE_ORDER, payload: dto });

 
const initialState = {
  list:    [],
  loading: false,
  error:   null,
};
export default function ordersReducer(state = initialState, action) {
  switch (action.type) {
    case FETCH_ORDERS:
    case CREATE_ORDER:
      return { ...state, loading: true, error: null };

    case FETCH_ORDERS_OK:
      return { ...state, loading: false, list: action.payload };

    case CREATE_ORDER_OK:
      return {
        ...state,
        loading: false,
        list: [ action.payload, ...state.list ]
      };

    case FETCH_ORDERS_ERR:
    case CREATE_ORDER_ERR:
      return { ...state, loading: false, error: action.error };

    default:
      return state;
  }
}


function* handleFetch() {
  try {
    const data = yield call(api.getAllOrders);
    yield put({ type: FETCH_ORDERS_OK, payload: data });
  } catch (err) {
    yield put({ type: FETCH_ORDERS_ERR, error: err.message });
  }
}

function* handleCreate(action) {
  try {
    const created = yield call(api.createOrder, action.payload);
    yield put({ type: CREATE_ORDER_OK, payload: created });
  } catch (err) {
    yield put({ type: CREATE_ORDER_ERR, error: err.message });
  }
}

export function* watchOrders() {
  yield takeLatest(FETCH_ORDERS, handleFetch);
  yield takeLatest(CREATE_ORDER, handleCreate);
}
