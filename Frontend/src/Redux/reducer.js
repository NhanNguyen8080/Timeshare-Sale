const initialState = {
    properties: [],
    filter: '',
    searchInput: '',
  };
  
  const rootReducer = (state = initialState, action) => {
    switch (action.type) {
      case 'SET_PROPERTIES':
        return {
          ...state,
          properties: action.payload,
        };
  
      case 'SET_FILTER':
        return {
          ...state,
          filter: action.payload,
        };
      
      // case 'SET_SEARCH_INPUT':
      // return {
      //   ...state,
      //   searchInput: action.payload,
      // };

      
  
      default:
        return state;
    }
  };
  
  export default rootReducer;
  