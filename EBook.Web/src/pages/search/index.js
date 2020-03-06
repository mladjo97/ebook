import React from 'react';
import { useDispatch } from 'react-redux';

import Search from '../../components/search';
import EBooks from '../../components/ebooks';
import { searchEBooks } from '../../redux/actions/ebooks';

import './index.css';

const SearchPage = () => {

  const dispatch = useDispatch();

  const onSubmitHandler = query => {
    if(!query) return;
    
    dispatch(searchEBooks(query));
  }

  return (
    <div className="search-page">
      <Search label="E-Book content" submitHandler={onSubmitHandler} />
      <EBooks />
    </div>
  )
};

export default SearchPage;