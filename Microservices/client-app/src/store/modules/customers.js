
import { call, put, takeLatest } from 'redux-saga/effects';
import * as api from '../../api/customers';


const FETCH_CUSTOMERS      = 'customers/FETCH';
const FETCH_CUSTOMERS_OK   = 'customers/FETCH_OK';
const FETCH_CUSTOMERS_ERR  = 'customers/FETCH_ERR';

const CREATE_CUSTOMER      = 'customers/CREATE';
const CREATE_CUSTOMER_OK   = 'customers/CREATE_OK';
const CREATE_CUSTOMER_ERR  = 'customers/CREATE_ERR';


export const fetchCustomers  = () => ({ type: FETCH_CUSTOMERS });
export const createCustomer  = dto => ({ type: CREATE_CUSTOMER, payload: dto });


const initialState = {
  list:    [],
  loading: false,
  error:   null,
};
export default function customersReducer(state = initialState, action) {
  switch (action.type) {
    case FETCH_CUSTOMERS:
    case CREATE_CUSTOMER:
      return { ...state, loading: true, error: null };

    case FETCH_CUSTOMERS_OK:
      return { ...state, loading: false, list: action.payload };

    case CREATE_CUSTOMER_OK:
      return {
        ...state,
        loading: false,
        list: [ ...state.list, action.payload ]
      };

    case FETCH_CUSTOMERS_ERR:
    case CREATE_CUSTOMER_ERR:
      return { ...state, loading: false, error: action.error };

    default:
      return state;
  }
}


function* handleFetch() {
  try {
    const data = yield call(api.getAllCustomers);
    yield put({ type: FETCH_CUSTOMERS_OK, payload: data });
  } catch (err) {
    yield put({ type: FETCH_CUSTOMERS_ERR, error: err.message });
  }
}

function* handleCreate(action) {
  try {
    const created = yield call(api.createCustomer, action.payload);
    yield put({ type: CREATE_CUSTOMER_OK, payload: created });
  } catch (err) {
    yield put({ type: CREATE_CUSTOMER_ERR, error: err.message });
  }
}

export function* watchCustomers() {
  yield takeLatest(FETCH_CUSTOMERS, handleFetch);
  yield takeLatest(CREATE_CUSTOMER, handleCreate);
}
