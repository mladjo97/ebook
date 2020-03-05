import React from 'react';
import { useDispatch } from 'react-redux';

import Search from '../../components/search';
import EBooks from '../../components/ebooks';
import { searchEBooks } from '../../redux/actions/ebooks';

const SearchPage = () => {

  const dispatch = useDispatch();

  const onSubmitHandler = query => {
    if(!query) return;
    
    dispatch(searchEBooks(query));
  }

  return (
    <React.Fragment>
      <Search label="E-Book title" submitHandler={onSubmitHandler} />
      <EBooks />
    </React.Fragment>
  )
};

export default SearchPage;