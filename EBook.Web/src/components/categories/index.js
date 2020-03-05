import React, { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { categoriesSelector } from '../../redux/reducers/categories';
import { getCategories } from '../../redux/actions/categories';
import Category from '../category';

const Categories = () => {
  const categories = useSelector(categoriesSelector);
  
  const dispatch = useDispatch();
  useEffect(() => { dispatch(getCategories()) }, [ dispatch ]);
  
  return (
    <React.Fragment>
      <h2>Categories</h2>
      {
         categories.map(cat => <Category key={cat.id} name={cat.name}/>)
      }
    </React.Fragment>
  );
};


export default Categories;