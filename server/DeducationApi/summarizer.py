from gensim.summarization import summarize
import sys

def main():
    text = sys.stdin.read()
    summary = summarize(text)
    print(summary)

if __name__ == "__main__":
    main()
