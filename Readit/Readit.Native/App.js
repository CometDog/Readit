import React from 'react';
import { StyleSheet, Text, View, FlatList } from 'react-native';

export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [
        { title: 'Hello, world!', subreddit: '/foo', author: 'pramser' },
        { title: 'Foo bar', subreddit: '/bar', author: 'jdowns' }
      ]
    };
  }

  async componentDidMount() {
    fetch('https://www.reddit.com/.json')
      .then(function(res) {
        return res.json();
      })
      .then(json => this.setState({ posts: json.data.children }))
      .catch(err => console.log(err));
  }

  render() {
    return (
      <View style={styles.app}>
        <FlatList
          style={styles.posts}
          data={this.state.posts}
          keyExtractor={(item, index) => index}
          renderItem={({ title, subreddit, author }) => (
            <Story title={title} sub={subreddit} author={author} />
          )}
        />
      </View>
    );
  }
}

class Story extends React.Component {
  render() {
    return (
      <View style={styles.story}>
        <Text>{this.props.title}</Text>
        <Text>{this.props.sub}</Text>
        <Text>{this.props.author}</Text>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  app: {
    backgroundColor: '#fff',
    marginTop: 30,

    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  },
  posts: {},
  story: {
    backgroundColor: '#ddd',

    width: 330,
    height: 100,
    marginTop: 10,

    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  }
});
