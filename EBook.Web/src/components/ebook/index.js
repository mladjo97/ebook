import React from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Highlighter from 'react-highlight-words';

import './index.css';

const EBook = ({ eBook }) => {
  const { author, title, highlights } = eBook;

  const highlightedContent = highlights["file.content"][0];
  const content = highlightedContent.replace(/<\/?strong>/g, '');
  const highlightTerms = highlightedContent.match(/<strong>(.*?)<\/strong>/g).map(val =>
    val.replace(/<\/?strong>/g,''));

  return (
    <Card variant="outlined" className="ebook-card">
      <CardContent>
        <Typography color="textSecondary" gutterBottom>
          {author}
        </Typography>
        <Typography variant="h5" component="h2">
          {title}
        </Typography>
        <Typography variant="body2" component="p">
          <Highlighter
            searchWords={highlightTerms}
            autoEscape={true}
            textToHighlight={`... ${content} ...`}
          />
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">See details</Button>
      </CardActions>
    </Card>
  );
};

export default EBook;
