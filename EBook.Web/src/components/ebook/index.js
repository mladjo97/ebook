import React from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import './index.css';

const EBook = ({ eBook }) => {

  const { author, highlights } = eBook;

  const highlightedTitle = highlights.title[0];

  return (
    <Card variant="outlined" className="ebook-card">
      <CardContent>
        <Typography color="textSecondary" gutterBottom>
          {author}
        </Typography>
        <Typography variant="h5" component="h2">
          { highlightedTitle }
        </Typography>
        <Typography variant="body2" component="p">
          {'Content preview here ...'}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">See details</Button>
      </CardActions>
    </Card>
  );
};

export default EBook;